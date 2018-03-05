namespace VideoStoreManagementSystemConsole
{
    public class Customer
    {
        private int membershipId;
        private string name;
        private string phoneNumber;

        public Customer(int membershipId, string name, string phoneNumber)
        {
            this.membershipId = membershipId;
            this.name = name;
            this.phoneNumber = phoneNumber;
        }

        public int getMembershipId()
        {
            return membershipId;
        }

        public void setMembershipId(int membershipId)
        {
            this.membershipId = membershipId;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getPhoneNumber()
        {
            return phoneNumber;
        }

        public void setphoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
        }

        public string tostring()
        {
            return this.getMembershipId() + " - " + this.getName() + " - " + this.getPhoneNumber();
        }
    }
}