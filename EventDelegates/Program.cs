namespace EventDelegates
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // create a form which contains Button

            Form form = new Form();
            // subscribe to button click event
            form.SubscribeToButtonClick();

            // simulate button click from the form 

            form.FormButtonClicked(null, EventArgs.Empty);

            Console.ReadLine();
        }
    }

   public  delegate void ButtonClicked();
    class Button
    {
        public event ButtonClicked Click;
        public void OnClick()
        {
            Click?.Invoke();
        }
    }
    class Form
    {
        public Button button { get; set; }
        public Form()
        {
            button = new Button();
        }
        public void SubscribeToButtonClick()
        {
            button.Click += () => { Console.WriteLine("Anonymous method Button Clicked handled "); };
        }

        // event handler
        public void FormButtonClicked(object sender, EventArgs e)
        {
           
           button.OnClick();
        }
    }
}
