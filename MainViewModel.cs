using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp1.BLL;
using WpfApp1.Model;

namespace WpfApp1
{
    public class list:ViewModelBase
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value;NotifyPropertyChanged("Name"); } }
        private int _id;
        public int ID { get { return _id; } set { _id = value;NotifyPropertyChanged("ID"); } }
        private string _mob;
        public string Mob { get { return _mob; } set { _mob = value;NotifyPropertyChanged("Mob"); } }
        private int _activetype;
        public int ActiveType { get { return _activetype; } set { _activetype = value; NotifyPropertyChanged("Mob"); } }
    }

    public class ComboItem : ViewModelBase
    {
        private string _name;
        public string cName { get { return _name; } set { _name = value; NotifyPropertyChanged("cName"); } }

    }
    
    public class ActiveTypeViewModel : ViewModelBase
    {
        private int _id;
        public int ID
        {
            get { return _id; }
            set 
            {
                _id = value;
                NotifyPropertyChanged("ID");
            }
        }
        private string _name;

        public string Name 
        {
            get { return _name; }
            set
            {
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }
    }
    
    public class MainViewModel : ViewModelBase
    {
   
        private int TatolPage = 0;
        private int CurrentPage = 0;
        private const int PageSize = 4;

        private string _mobile;

        public string Mobile { get { return _mobile;  } set { _mobile = value;NotifyPropertyChanged("Mobile"); }  }

        private ActiveTypeViewModel _activetype;
        public ActiveTypeViewModel ActiveType { get {
                return _activetype; 
            } set { _activetype = value;NotifyPropertyChanged("ActiveType"); } }


        Dictionary<int, string> ActiveTypeDic = new Dictionary<int, string>();
        public ObservableCollection<ActiveTypeViewModel> activeTypeViewModels { get; set; }
        static MainViewModel _mainVM = new MainViewModel();
        UserBAL userBAL;
     
        public MainViewModel()
        {
           
            tt = new ObservableCollection<list>();
             userBAL = new UserBAL();
            userBAL.Init();
            int Pages = userBAL.GetTatolPage("",0,PageSize);
            TatolPage = Pages;
            if (TatolPage > 0)
            {
                CurrentPage = 1;
                var u = userBAL.GetUserModel(CurrentPage, PageSize, "", 0, 0);
                SetView(u);
            }
            SetActiveType(userBAL.GetActiveTypeModels());
            PrePageCmd = new Command(prepagecmd);
            NextPageCmd = new Command(nextpagecmd);
            Select = new Command(select);
            Mobile = "";
            ActiveType = activeTypeViewModels[0];

        }
        public string GetActiveTypeString(int index)
        {
            if (ActiveTypeDic.ContainsKey(index))
            {
                return ActiveTypeDic[index];
            }
            return default(string);
        }
        void SetActiveType(List<ActiveTypeModel> models)
        {
            activeTypeViewModels = new ObservableCollection<ActiveTypeViewModel>();
            activeTypeViewModels.Add(new ActiveTypeViewModel() { ID = 0 ,Name="全部"});
            foreach (ActiveTypeModel model in models)
            {
                ActiveTypeDic[model.ID] = model.Name;
                ActiveTypeViewModel active = new ActiveTypeViewModel();
                active.ID = model.ID;
                active.Name = model.Name;
                activeTypeViewModels.Add(active);
            }
        }

        public void ActiveTypeChange()
        {
            
        }

        void SetView(List<UserModel> userModels)
        {
       
            tt.Clear();
            foreach (var um in userModels)
            {
                list l = new list();
                l.ID = um.ID;
                l.Name = um.Name;
                l.Mob = um.Mobile;
                l.ActiveType = um.ActiveType;
                tt.Add(l);
            }
          
        }

        public ObservableCollection<list> tt { get; set; }
  



        public Command command { get;  }
      
        public Command PrePageCmd
        {
            get;
            set;
        }
        public Command NextPageCmd
        {
            get;
            set;
        }

        public Command Select 
        {
            get;
            set;
        }
        private void command_(object param)
        {
            Console.WriteLine(Data);
            Instance.Age += 1;
        }
        private void prepagecmd(object param)
        {
            if (CurrentPage - 1 > 0&& TatolPage>0)
            {
                
                CurrentPage--;
               var us= userBAL.GetUserModel(CurrentPage, PageSize, Mobile, ActiveType.ID, 0);
                SetView(us);
            }
        }
        private void nextpagecmd(object param)
        {
            if (CurrentPage +1 <= TatolPage && TatolPage > 0)
            {
                CurrentPage++;
               var us =userBAL.GetUserModel(CurrentPage, PageSize, Mobile, ActiveType.ID, 0);
                SetView(us);
            }
        }

        public void select(object param)
        {
            Mobile  = param as string;
            int id = ActiveType.ID;
            int Pages = userBAL.GetTatolPage(Mobile, id, PageSize);
            TatolPage = Pages;
            if (TatolPage > 0)
            {
                CurrentPage = 1;
                var u = userBAL.GetUserModel(CurrentPage, PageSize, Mobile, id, 0);
                SetView(u);
            }
            else
            {
                SetView(new List<UserModel>());
            }
        }


        
        public static MainViewModel Instance
        {
            get { return _mainVM; }
        }
        private string name;

        public string Name
        {
            get { return name; }
            set { 
                name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private string data;
        public string Data
        {
            get { return data; }
            set { data = value;NotifyPropertyChanged("Data"); }
        }

        private int age;

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                NotifyPropertyChanged("Age");
            }
        }
       

    }
}
