using System.Collections.Generic;

namespace Bingo
{
    public class FixedItemsSource : IBoardItemsSource
    {
        public IEnumerable<string> GetBoardItems()
        {
            yield return "Hi, who just joined";
            yield return "Can you e-mail that to everyone?";
            yield return "_, are you there?";
            yield return "Uh, _, you are still sharing...";
            yield return "I have ot jump to another call";
            yield return "(Sound of someone typing, possibly with a hammer)";
            yield return "(loud painful echo/feedback)";
            yield return "(child or animal noises)";
            yield return "Hi, can you hear me?";
            yield return "No, it's still loading.";
            yield return "Next slide please";
            yield return "Can everyone go on mute?";
            yield return "I'm sorry I was on mute";
            yield return "(For over-talkers) Sorry go ahead";
            yield return "Hello? Hello?";
            yield return "So (faded out). I can (unintelligible). By (cuts out) Ok?";
            yield return "Sorry I'm late. (Insert lame excuse)";
            yield return "I have a hard stop at ...";
            yield return "I'm sorry, you cut out there";
            yield return "Can we take this offline";
            yield return "I'll have ot get back to you";
            yield return "Can everyone see my screen?";
            yield return "Sorry I was having connection issues";
            yield return "I think there's a lag";
            yield return "Sorry I didn't catch that, can you repeat?";
        }
    }
}