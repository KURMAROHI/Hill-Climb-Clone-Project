

using UnityEngine;
using UnityEditor;

public class SpriteFontCreator : EditorWindow
{
    // Array to store individual character sprites

    public Sprite[] characterSprites;

    // Font texture
    public Texture2D fontTexture;

    // Font material
    public Material fontMaterial;

    // Font size
    public int fontSize = 32;

    // Character mappings
    public string characterMappings = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

    // Create menu item
    [MenuItem("Tools/Create Sprite Font")]
    public static void ShowWindow()
    {
        GetWindow<SpriteFontCreator>("Create Sprite Font");
    }

    // GUI
    private void OnGUI()
    {

        var serializedObject = new SerializedObject(this);
        var property = serializedObject.FindProperty("characterSprites");
        serializedObject.Update();
        EditorGUILayout.PropertyField(property, true);
        serializedObject.ApplyModifiedProperties();

        GUILayout.Label("Sprite Font Settings", EditorStyles.boldLabel);
        GUILayout.BeginVertical();
        GUILayout.Label("Character Sprites", GUILayout.Width(120));
        if (characterSprites != null)
        {
            for (int i = 0; i < characterSprites.Length; i++)
            {
                characterSprites[i] = EditorGUILayout.ObjectField("Sprite " + i, characterSprites[i], typeof(Sprite), true) as Sprite;
            }
        }

        GUILayout.EndVertical();

        fontTexture = EditorGUILayout.ObjectField("Font Texture", fontTexture, typeof(Texture2D), false) as Texture2D;
        fontMaterial = EditorGUILayout.ObjectField("Font Material", fontMaterial, typeof(Material), false) as Material;

        fontSize = EditorGUILayout.IntField("Font Size", fontSize);

        characterMappings = EditorGUILayout.TextField("Character Mappings", characterMappings);

        if (GUILayout.Button("Create Font"))
        {
            CreateFont();
        }
    }

    // Method to create the sprite font
    private void CreateFont()
    {
        if (characterSprites == null || characterSprites.Length == 0)
        {
            Debug.LogError("No character sprites provided.");
            return;
        }

        if (characterMappings.Length != characterSprites.Length)
        {
            Debug.LogError("Character sprites count doesn't match character mappings count.");
            return;
        }

        // Create new font
        Font font = new Font();

        // Assign material
        font.material = fontMaterial;

        // Initialize character info array
        CharacterInfo[] characterInfo = new CharacterInfo[characterSprites.Length];

        // Assign character info
        for (int i = 0; i < characterSprites.Length; i++)
        {
            CharacterInfo info = new CharacterInfo();
            info.index = (int)characterMappings[i];
            info.uvTopLeft = Vector2.zero;
            info.uvTopRight = new Vector2(1, 0);
            info.uvBottomLeft = new Vector2(0, 1);
            info.uvBottomRight = Vector2.one;
            info.vert = new Rect(0, 0, characterSprites[i].texture.width, characterSprites[i].texture.height);
            info.width = characterSprites[i].texture.width;
            info.flipped = false;

            characterInfo[i] = info;
        }

        // Assign font info
        font.characterInfo = characterInfo;

        // Save font texture
        string fontTexturePath = AssetDatabase.GenerateUniqueAssetPath("Assets/FontTexture.png");
        byte[] bytes = fontTexture.EncodeToPNG();
        System.IO.File.WriteAllBytes(fontTexturePath, bytes);
        AssetDatabase.ImportAsset(fontTexturePath);
        TextureImporter textureImporter = AssetImporter.GetAtPath(fontTexturePath) as TextureImporter;
        textureImporter.textureType = TextureImporterType.Sprite;
        textureImporter.spriteImportMode = SpriteImportMode.Single;
        textureImporter.alphaIsTransparency = true;
        textureImporter.mipmapEnabled = false;
        AssetDatabase.ImportAsset(fontTexturePath, ImportAssetOptions.ForceUpdate);

        // Assign font texture
        font.material.mainTexture = AssetDatabase.LoadAssetAtPath<Texture2D>(fontTexturePath);

        // Save font asset
        string fontPath = AssetDatabase.GenerateUniqueAssetPath("Assets/Sprites/BG/NewFont.asset");
        AssetDatabase.CreateAsset(font, fontPath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("Sprite font created successfully at: " + fontPath);
    }
}