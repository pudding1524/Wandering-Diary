using UnityEngine;


public class Dialogue : MonoBehaviour
{
    public string Charactername = "???";
    public GameObject CharacterImage;
    public GameObject NextConversation;
    public GameObject ChooseBranch;
    public GameObject BackgroundImage;
    public int fontsize = 26;
    [TextArea(3, 10)]
    public string[] sentences;
}
