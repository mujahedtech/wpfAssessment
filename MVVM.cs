using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using System.Xml.Linq;

namespace wpfAssessment
{
    public class Categoires
    {

        public string Name { get; set; }

    }
    public class Channels
    {

        public string Name { get; set; }

        public int Count { get; set; }

    }

    public class ProfileInfo
    {

        public string Name { get; set; }
        public bool Status { get; set; }
        public string Image { get; set; }

    }



    public class MassegeData
    {

        public string Image { get; set; }
        public string UserName { get; set; }
        public DateTime date { get; set; }
        public string Message { get; set; }

        public DateTime Lastreplay { get; set; }
        public string NumberReplay { get; set; }

      public  List<ImagesListVm> images { get; set; }


    }


    public class ImagesListVm

    {

        public string name { get; set; } 

       public string imageSource { get; set; }


    }



    public class MVVM : ViewModel
    {


        #region Command
        public ICommand AddCatCommand { get; set; }
        private void AddCatCommandVoid(object parameter)
        {
            CategoiresList.Add(new Categoires { Name = "M" });

        }

        public ICommand SelectChannelCommand { get; set; }
        private void SelectChannelCommandVoid(object parameter)
        {
            var obj = (Channels)parameter;

            ChannelName = obj.Name;

            ChannelNote = $"📱 Channel for number {obj.Count}";





        }

        public ICommand AddChannelCommand { get; set; }
        private void AddChannelCommandVoid(object parameter)
        {
            Channelslist.Add(new Channels { Name = $"Channel-{(Channelslist.Count+1).ToString()}", Count = Channelslist.Count + 1 });

        }

        public ICommand SetBoldFontCommand { get; set; }
        private void SetBoldFonttVoid(object parameter)
        {
            if (FontWeightMvvM == FontWeights.Normal) FontWeightMvvM = FontWeights.Bold;
            else FontWeightMvvM = FontWeights.Normal;
            
        }

        public ICommand SetItalicFontCommand { get; set; }
        private void SetItalicFontVoid(object parameter)
        {
            if (FontStyleMvvm == FontStyles.Normal) FontStyleMvvm = FontStyles.Italic;
            else FontStyleMvvm = FontStyles.Normal;

        }


        public ICommand SentMessageCommand { get; set; }
        private void SentMessageVoid(object parameter)
        {

            MassegeDatas.Add(new MassegeData { UserName = "You", date = DateTime.Now, Image = @"Images\Image4.png", Lastreplay = new DateTime(2023, 6, 7, 13, 57, 00), NumberReplay = "", Message = MessageValue,  });


            MessageValue = "";

            _view.ScrollToEnd();

        }


        #endregion



        #region Lists
        private ObservableCollection<Categoires> categoires = new ObservableCollection<Categoires>();
        public ObservableCollection<Categoires> CategoiresList
        {
            get
            {

                return categoires;

            }
            set
            {
                categoires = value;
                OnPropertyChanged(nameof(CategoiresList));
            }

        }

        private ObservableCollection<Channels> channelslist = new ObservableCollection<Channels>();
        public ObservableCollection<Channels> Channelslist
        {
            get
            {

                return channelslist;

            }
            set
            {
                channelslist = value;
                OnPropertyChanged(nameof(Channelslist));
            }

        }



        private ObservableCollection<ProfileInfo> profileInfos = new ObservableCollection<ProfileInfo>();
        public ObservableCollection<ProfileInfo> ProfileInfos
        {
            get
            {

                return profileInfos;

            }
            set
            {
                profileInfos = value;
                OnPropertyChanged(nameof(ProfileInfos));
            }

        }




        private ObservableCollection<MassegeData> massegeDatas = new ObservableCollection<MassegeData>();
        public ObservableCollection<MassegeData> MassegeDatas
        {
            get
            {

                return massegeDatas;

            }
            set
            {
                massegeDatas = value;
                OnPropertyChanged(nameof(MassegeDatas));
            }

        }


        #endregion


        private readonly IMyView _view;
        public MVVM(IMyView view)
        {

            _view = view;

            AddCatCommand = new RelayCommand(AddCatCommandVoid);
            AddChannelCommand = new RelayCommand(AddChannelCommandVoid);
            SelectChannelCommand = new RelayCommand(SelectChannelCommandVoid);

            SetBoldFontCommand = new RelayCommand(SetBoldFonttVoid); 
            SetItalicFontCommand = new RelayCommand(SetItalicFontVoid);

            SentMessageCommand= new RelayCommand(SentMessageVoid);


            CategoiresList.Add(new Categoires { Name = "A" });
            CategoiresList.Add(new Categoires { Name = "B" });
            CategoiresList.Add(new Categoires { Name = "C" });



            Channelslist.Add(new Channels { Name = "Channel-1",Count= Channelslist.Count + 1 });
            Channelslist.Add(new Channels { Name = "Channel-2", Count = Channelslist.Count + 1 });
            Channelslist.Add(new Channels { Name = "Channel-3", Count = Channelslist.Count + 1 });
            Channelslist.Add(new Channels { Name = "Channel-4" ,Count = Channelslist.Count + 1});
            Channelslist.Add(new Channels { Name = "Channel-5", Count = Channelslist.Count + 1 });
            Channelslist.Add(new Channels { Name = "Channel-6", Count = Channelslist.Count + 1 });
            Channelslist.Add(new Channels { Name = "Channel-7", Count = Channelslist.Count + 1 });


            ProfileInfos.Add(new ProfileInfo { Name = "HHH",Status=true ,Image= @"Images\Image1.jpg" });
            ProfileInfos.Add(new ProfileInfo { Name = "Heal", Status = true, Image = @"Images\Image2.png" });
            ProfileInfos.Add(new ProfileInfo { Name = "Kamran", Status = false, Image = @"Images\Image2.png" });







            //MassegeDatas.Add(new MassegeData { UserName = "Kamran", date = new DateTime(2023, 3, 1, 18, 49, 00), Image = @"Images\Image4.png", Lastreplay = new DateTime(2023, 6, 7, 13, 57, 00), NumberReplay = "3", Message = "봄날의 햇살 따라 새벽길을 걷네, 작은 꽃들이 눈부신 향기를 품고 서로 맞닿아 웃네.\n 나비들은 춤추며 색다른 세계를 만들어가고, 그 속에서 나는 풍경에 녹아들어 자유롭게 흘러가네.\n 어린 그림자들이 덧없이 노래하며 흐르고, 푸른 하늘은 감탄을 자아내며 펼쳐진다.\n 저 멀리 산들은 우리에게 약속을 전하고, 물결처럼 흐르는 강물은 시간을 담고 흘러간다.\n 끝없이 이어지는 세상의 수레바퀴, 그 안에서 나는 작은 하나의 이야기가 되어 흘러간다.", images = new List<ImagesListVm> { new ImagesListVm { imageSource = @"Images\Image1.png" }, new ImagesListVm { imageSource = @"Images\Image2.png" }, new ImagesListVm { imageSource = @"Images\Image3.png" } } });
            MassegeDatas.Add(new MassegeData { UserName = "Kamran", date = new DateTime(2023, 3, 1, 18, 49, 00), Image = @"Images\Image4.png", Lastreplay = new DateTime(2023, 6, 7, 13, 57, 00), NumberReplay = "2", Message = "봄날의 햇살 따라 새벽길을 걷네, 작은 꽃들이 눈부신 향기를 품고 서로 맞닿아 웃네. 나비들은 춤추며 색다른 세계를 만들어가고, 그 속에서 나는 풍경에 녹아들어 자유롭게 흘러가네. 어린 그림자들이 덧없이 노래하며 흐르고, 푸른 하늘은 감탄을 자아내며 펼쳐진다. 저 멀리 산들은 우리에게 약속을 전하고, 물결처럼 흐르는 강물은 시간을 담고 흘러간다. 끝없이 이어지는 세상의 수레바퀴, 그 안에서 나는 작은 하나의 이야기가 되어 흘러간다.", images = new List<ImagesListVm> { new ImagesListVm { imageSource = @"Images\Imagetop3.png" }, new ImagesListVm { imageSource = @"Images\Imagetop1.png" }, new ImagesListVm { imageSource = @"Images\Imagetop2.png" } } });
            MassegeDatas.Add(new MassegeData { UserName = "Kamran", date = new DateTime(2023, 6, 7, 18, 49, 00), Image = @"Images\Image1.png", Lastreplay = new DateTime(2023, 6, 7, 13, 57, 00), NumberReplay = "", Message = "그 안에서 나는 작은 하나의 이야기가 되어 흘러간다." });



        }

        #region Constractors

        public string ChannelName { get; set; } = "Cjannel";

        public string ChannelNote { get; set; }

        public string MessageValue { get; set; } = "45646";


        public FontWeight FontWeightMvvM { get; set; } = FontWeights.Normal;
        public FontStyle FontStyleMvvm { get; set; } = FontStyles.Normal;



        #endregion







    }
}
