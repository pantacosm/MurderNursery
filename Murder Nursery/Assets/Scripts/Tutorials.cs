using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutorials : MonoBehaviour
{
    public string pinboardTutorial = "This is the place where it all comes together! Every aspiring detective needs a pinboard.\r\n\r\nAll the evidence you gather while investigating will be collected in a list at the bottom of your pinboard. You can scroll through this with your mouse and hover over evidence to see a short blurb that describes it. \r\n\r\nTo assign evidence to a specific classmate, left-click and drag the evidence to the pinboard. Then, you need to left-click that character’s portrait to drop a pin, and left-click the piece of evidence you’d like to assign, to thread them together. Once this has been done, you are able to present these as clues if needed at interrogations! If they’re correct, of course…\r\n\r\nFinally, if you change your mind - to unassign a piece of evidence from a character, simply right-click on it. That should send it back to the evidence section.\r\n\r\nIf you think you’re still missing some crucial clues; get out there and chat to your classmates, use some of your detective kit, or succeed in interrogations!";
    public string bribeTutorial = "Got a bribe? Perfect! Now you’re a real detective. \r\n\r\nWhile in dialogue, you can choose to give this to one of your classmates by left-clicking on the item you’d like to bribe with in the top left corner of your screen. If you’re lucky, they may decide to give you a little more information… \r\n\r\nBe careful though - some of your friends won’t like certain gifts! You can find clues as to who may like each item by using your detective kit, interrogating, and talking to everyone. \r\n\r\nAnd remember: once you’ve chosen to use a bribe, you cannot use it on another classmate - so choose wisely! \r\n";
    public string dressupTutorial = "Need a disguise? The dress-up box has you covered! \r\n\r\nSimply walk to the shelves by Juice Box and press “E” to access three extra outfits for you to try on: the gangster, the artist, and the punk. Left-click the costume you’d like to change into. Once you switch an outfit, it will replace the old one in the box, so remember to come back if you’d like to get back into your detective gear later.\r\n\r\nDressing up is crucial in order to stealthily listen into conversations or to get classmates to drop their guard. Try some costumes out on your friends in dialogue too - you never know what might end up happening!\r\n";
    public string interrogationTutorial = "It’s time to play bad cop, bad cop. Let’s get interrogating! \r\n\r\nEach of the classmates you can speak to has the option to begin an interrogation at any time once you open dialogue with them. You should be able to see how many pieces of evidence you need to successfully complete the interrogation, and how many of those you currently have - either assigned correctly, or incorrectly! \r\n\r\nOnce inside the interrogation, you must refute the statements of your friends with the correct pieces of evidence by navigating to the correct section of the pinboard and clicking on the icon you’d like to present. If you get this right, you will proceed to the next stage of the interrogation. Each interrogation has a different number of stages and required pieces of evidence, so be careful - some of your friends are trickier to get talking than others! \r\n\r\nIf you give an incorrect piece of evidence or statement, you will lose a life - one of five - and if all are lost, you’ll be kicked from the interrogation altogether. Don’t worry though: when you re-enter, you’ll start where you left off last time. Find more evidence, move it around, and keep trying!\r\n\r\nThese interrogations are crucial for uncovering potential motives and backstory, so discover as much as you can to unravel the mystery!\r\n";
    public string magnifyingGlassTutorial = "Let’s split up and look for clues! \r\n\r\nYou can select the magnifying glass from your inventory. This should freeze you in place, where you can zoom in on your surroundings by moving the mouse! If you’re standing close enough to a clue, it should stand out somehow… You can left-click to inspect it and obtain a valuable piece of evidence! Make sure you explore and search thoroughly, as some clues will only appear through the magnifying glass.\r\n\r\nAll pieces of evidence will be added to the pinboard, so remember to check there and assign it correctly for your interrogations!\r\n";
    public string fingerprintTutorial = "You’re pretty sure you saw this on CSI once… \r\n\r\nThe fingerprint kit can be accessed from your inventory. It should bring up a list of clues you’ve found around the nursery! You can click on each one individually to see whether or not you’ve found a fingerprint on that item, and if so, whether that fingerprint has been matched to a culprit in the classroom! \r\n\r\nFinding the fingerprint is pretty easy. Just rotate the item until you see something that looks suspicious. Matching the fingerprint is a little more tricky… look carefully amongst the other fingerprints to see which one is the closest match! Once you’ve figured that out, you should be able to get a little more insight into the story behind that clue.\r\n\r\nOnce both these steps are completed, the evidence should be added to your pinboard, so remember to check back there to assign it correctly!\r\n\r\n";
    public string ldTutorial = "Did you hear something? Must’ve been the wind…\r\n\r\nWhy bother waiting around for your classmates to give you the information you need? If you come across certain hiding spots within the room, you can hide and listen in on private conversations to obtain more evidence! Be careful though - you’ll need to be wearing a disguise in order to access these locations, so make sure you visit the dress-up box first.\r\n\r\nTo revisit overheard conversations, simply visit the listening device through your inventory, where you can scroll through a transcript and make some deductions. Remember the evidence you discover will also be added to the pinboard, so remember to visit and assign it to your chosen classmate!\r\n";
    public string popQuiz = "Reading is fundamental! Are you keeping up with your education?\r\n\r\nEvery so often once you’ve collected certain amounts and pieces of evidence, you may get a surprise pop quiz! Questions will appear on your screen and you must select what you believe to be the correct answers to continue. At the end of your quiz, you’ll be shown how many you got wrong or right - but not which ones! That would be cheating, right? \r\n\r\nStay tuned for the credits to find out whether you’re a straight A student!\r\n";
   
    public string inventoryTutorial = "This is your trusty inventory, where you will find all manner of crime solving tools. You can get a preview of what each item does by hovering over it with the mouse.You can then select any item in the inventory by left-clicking.";
    public string notebookTutorial = "What detective would be complete without a notebook? This is where you will find helpful information such as tutorials, interrogation summaries, and listening conversation recaps.Browse at your pleasure!";

    public GameObject tutorialPanel;
    public GameObject tutorialText;
    public bool firstLD = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateTutorial(string message)
    {
        tutorialPanel.SetActive(true);
        tutorialText.GetComponent<TextMeshProUGUI>().text = message;
    }

    public void DeactivateTutorial()
    {
        tutorialPanel.SetActive(false);
        Time.timeScale = 1.0f;
        
    }
    
}
