namespace ConsoleReader.Core
{
    public class UserActionsLocker
    {
        private bool locked=false;
        
        public bool GetState()
        {
            return locked;
        }
        public void Lock()
        {
            locked = true;
        }
        public void Unlock()
        {
            locked = false;
        }
    }
}
