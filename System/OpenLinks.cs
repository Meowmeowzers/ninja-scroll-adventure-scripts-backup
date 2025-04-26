using UnityEngine;

public class OpenLinks : MonoBehaviour
{
    public void OpenProfile()
    {
        Application.OpenURL("https://github.com/Meowmeowzers");
    }
    public void OpenArtAssets()
    {
        Application.OpenURL("https://pixel-boy.itch.io/ninja-adventure-asset-pack");
    }
    public void OpenFont()
    {
        Application.OpenURL("https://www.fontspace.com/eight-bit-dragon-font-f30428");
    }
}
