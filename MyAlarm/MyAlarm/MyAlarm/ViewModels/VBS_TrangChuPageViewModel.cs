using Logic;
using MyAlarm.EFStandard;
using MyAlarm.Helpers;
using MyAlarm.Model;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MyAlarm.ViewModels
{
    class VBS_TrangChuPageViewModel : BaseViewModel
    {
        public VBS_TrangChuPageViewModel(InitParamVm initParamVm) : base(initParamVm)
        {
        }
 
        #region ListMemberBindProp
        private ObservableCollection<Member> _ListMemberBindProp = new ObservableCollection<Member>();
        public ObservableCollection<Member> ListMemberBindProp
        {
            get { return _ListMemberBindProp; }
            set { SetProperty(ref _ListMemberBindProp, value); }
        }
        #endregion

        #region SelectedMemberBindProp
        private Member _SelectedMemberBindProp = null;
        public Member SelectedMemberBindProp
        {
            get { return _SelectedMemberBindProp; }
            set { SetProperty(ref _SelectedMemberBindProp, value); }
        }
        #endregion


        #region GetListMemberCommand

        public DelegateCommand<object> GetListMemberCommand { get; private set; }
        private void OnGetListMember(object obj)
        {
            if (IsBusyBindProp)
            {
                return;
            }

            IsBusyBindProp = true;

            // Thuc hien cong viec tai day
            var logic_Member = new MemberLogic(Helper.GetConnectionString());

            var listMember = logic_Member.GetAllAsync();

            IsBusyBindProp = false;
        }

        [Initialize]
        private void InitGetListMemberCommand()
        {
            GetListMemberCommand = new DelegateCommand<object>(OnGetListMember);
            GetListMemberCommand.ObservesCanExecute(() => IsNotBusyBindProp);
        }

        #endregion

    }
}
