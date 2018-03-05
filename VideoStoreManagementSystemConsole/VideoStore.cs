using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VideoStoreManagementSystemConsole
{
    public class VideoStore
    {
        private Dictionary<int, Customer> customerList = new Dictionary<int, Customer>();
        private Dictionary<int, VideoPlus> videoList = new Dictionary<int, VideoPlus>();
        private Dictionary<int, List<VideoRental>> rentVideoList = new Dictionary<int, List<VideoRental>>();

        //public void addVideo(string title, string category, int numberOfCopies)
        //{
        //    VideoPlus video = new VideoPlus(videoList.Count() + 1, title, category, numberOfCopies, true);
        //    videoList.Add(videoList.Count() +1, video);
            
        //}

        public void addMember(string name, string phoneNumber)
        {
            Customer customer = new Customer(customerList.Count() + 1, name, phoneNumber);
            customerList.Add(customerList.Count() + 1, customer);
            Console.WriteLine("Member id is : {0}", customerList.Count());
        }

        public void addRentVideoList(int membershipId, int videoId, int rentDays)
        {
            VideoRental videoRental = new VideoRental(videoId, videoList[videoId].getTitle(),videoList[videoId].getCategory(), rentDays, true );
            if (rentVideoList.ContainsKey(membershipId) == false)
            {
                rentVideoList.Add(membershipId,new List<VideoRental>());
                rentVideoList[membershipId].Add(videoRental);
            }
        }

        public void viewRentDue(int membershipId, LoanPolicy loanPolicy)
        {
            if (rentVideoList.ContainsKey(membershipId)==false)
            {
                Console.WriteLine("Nothing due!");
            }
            else
            {
                double duePayment = 0.0;
                Console.WriteLine("Id\t|\tTitle\t||\tCategory\t||\tRent Days");
                foreach (VideoRental videoRental in rentVideoList[membershipId])
                {
                    if (videoRental.isRent_status())
                    {
                        duePayment += videoRental.getrent_days() * loanPolicy.getPerday_rental_charge();
                        Console.WriteLine(videoRental.getId() + "\t|\t" + videoRental.getTitle() + "\t|\t" + videoRental.getCategory() + "\t|\t" + videoRental.getrent_days());
                    }
                    Console.WriteLine("Total Rent Due: {0}", duePayment);
                }
            }
        }

        public void paymentRentDue(int membershipId)
        {
            bool hasDueAmount = false;
            if (rentVideoList.ContainsKey(membershipId)==true)
            {
                foreach (VideoRental videoRental in rentVideoList[membershipId])
                {
                    if (videoRental.isRent_status())
                    {
                        hasDueAmount = true;
                        break;
                    }
                }
            }
            if (rentVideoList.ContainsKey(membershipId) == false || hasDueAmount == false)
            {
                Console.WriteLine("Nothing due");
            }
            else
            {
                foreach (VideoRental videoRental in rentVideoList[membershipId])
                {
                    videoRental.setRent_status(false);
                    videoList[videoRental.getId()].setNumberOfCopies(videoList[videoRental.getId()].getNumberOfCopies() + 1);
                }
                Console.WriteLine(customerList[membershipId].tostring());
                Console.WriteLine("Paid rent due payment successfully");
            }
        }

        public void displayVideos()
        {
               GetMovieData();
                Console.WriteLine("--End--");
        }

        public bool isMemberAvailable(int membershipId)
        {
            if (customerList.ContainsKey(membershipId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void decreaseAvailableCount(int video_id)
        {
            videoList[video_id].setNumberOfCopies(videoList[video_id].getNumberOfCopies() - 1);
        }

        public bool isVideoAvailable(int video_id)
        {
            if (videoList[video_id].getNumberOfCopies() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void GetMovieData()
        {
            string DataFile = "MovieData.txt";
            string Content = "Empty File";

            if (File.Exists(DataFile))
            {
                Content = File.ReadAllText(DataFile);
            }

            Console.WriteLine(Content);
        }
    }
}