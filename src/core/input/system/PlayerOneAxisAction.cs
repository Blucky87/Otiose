namespace Otiose.Input
{
    public class PlayerOneAxisAction : OneAxisInputControl
    {
        PlayerAction negativeAction;
        PlayerAction positiveAction;


        internal PlayerOneAxisAction(PlayerAction negativeAction, PlayerAction positiveAction)
        {
            this.negativeAction = negativeAction;
            this.positiveAction = positiveAction;

            Raw = true;
        }


        internal void Update()
        {
            var value = Utility.ValueFromSides(negativeAction, positiveAction);
            CommitWithValue(value);
        }
    }
}
