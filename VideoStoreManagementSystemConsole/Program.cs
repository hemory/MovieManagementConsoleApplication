using System;

namespace VideoStoreManagementSystemConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            VideoStore videoStore = new VideoStore();
            LoanPolicy loanPolicy = new LoanPolicy();
            loanPolicy.set_perday_rental_charge(20);

            while (true)
            {
                Console.WriteLine("BGK Video store");
                Console.WriteLine("1. Add video");
                Console.WriteLine("2. Add customer");
                Console.WriteLine("3. Rent video");
                Console.WriteLine("4. View due amount");
                Console.WriteLine("5. Pay due amount");
                Console.WriteLine("6. View videos");
                Console.WriteLine("7. Set rent per day amount");
                Console.WriteLine("0 to Exit");
                Console.WriteLine("Enter the choice as number(1 to 7)");

                int choice = Convert.ToInt32(Console.ReadLine());
                int membershipId;
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the title");
                        string videoTitle = Console.ReadLine();
                        Console.WriteLine("Enter the category");
                        string videoCategory = Console.ReadLine();
                        Console.WriteLine("Enter number of copies");
                        int videoCopies = Convert.ToInt32(Console.ReadLine());
                        videoStore.addVideo(videoTitle,videoCategory,videoCopies);
                        Console.WriteLine("The video was added successfully");
                        break;

                    case 2:
                        Console.WriteLine("Enter customer name");
                        string customerName = Console.ReadLine();
                        Console.WriteLine("Enter customer phone number");
                        string customerPhoneNumber = Console.ReadLine();
                        videoStore.addMember(customerName, customerPhoneNumber);
                        Console.WriteLine("The customer was added successfully");
                        break;

                    case 3:
                        Console.WriteLine("Enter the membership id");

                        membershipId = Convert.ToInt32(Console.ReadLine());
                        if (!videoStore.isMemberAvailable(membershipId))
                        {
                            Console.WriteLine("Membership id is not available");
                        }
                        else
                        {
                            videoStore.displayVideos();
                            while (true)
                            {
                                Console.WriteLine("Enter the video id(0 to exit)");
                                int videoId = Convert.ToInt32(Console.ReadLine());
                                if (videoId == 0)
                                {
                                    break;
                                }

                                Console.WriteLine("Enter the rent days");
                                int rentDays = Convert.ToInt32(Console.ReadLine());

                                if (videoStore.isVideoAvailable(videoId))
                                {
                                    videoStore.addRentVideoList(membershipId, videoId, rentDays);
                                    videoStore.decreaseAvailableCount(videoId);
                                }
                                else
                                {
                                    Console.WriteLine("Sorry, video is not available");
                                }
                            }
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter the membership id");
                        membershipId = Convert.ToInt32(Console.ReadLine());
                        if (!videoStore.isMemberAvailable(membershipId))
                        {
                            Console.WriteLine("Membership Id is not available");
                        }
                        else
                        {
                            videoStore.viewRentDue(membershipId, loanPolicy);
                            Console.WriteLine("--End--");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Enter the membership id");
                        membershipId = Convert.ToInt32(Console.ReadLine());
                        if (!videoStore.isMemberAvailable(membershipId))
                        {
                            Console.WriteLine("Membership Id is not available");
                        }
                        else
                        {
                            videoStore.paymentRentDue(membershipId);
                            Console.WriteLine("--End--");
                        }
                        break;
                    case 6:
                        videoStore.displayVideos();
                        break;

                    case 7:
                        Console.WriteLine("Enter the rental charge");
                        double perday_rental_charge = Convert.ToInt32(Console.ReadLine());
                        loanPolicy.set_perday_rental_charge(perday_rental_charge);
                        break;
                }
                if (choice == 0)
                {
                    break;
                }
            }
        }
    }
}
