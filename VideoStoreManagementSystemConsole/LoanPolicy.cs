namespace VideoStoreManagementSystemConsole
{
    public class LoanPolicy
    {
        private double perday_rental_charge;

        public double getPerday_rental_charge()
        {
            return perday_rental_charge;
        }

        public void set_perday_rental_charge(double perday_rental_charge)
        {
            this.perday_rental_charge = perday_rental_charge;
        }
    }
}