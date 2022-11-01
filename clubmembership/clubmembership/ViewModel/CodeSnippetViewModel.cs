using clubmembership.Models;
using clubmembership.Repository;
using System.ComponentModel.DataAnnotations;

namespace clubmembership.ViewModel
{
    public class CodeSnippetViewModel
    {
        public Guid IdcodeSnippet { get; set; }
        public string Title { get; set; } = null!;
        public string ContentCode { get; set; } = null!;
        public string MemberName { get; set; } 
        public Guid Idmember { get; set; }
        public int Revision { get; set; }
        public Guid? IdsnippetPreviousVersion { get; set; }

        [DisplayFormat(DataFormatString = "0:MM/dd/yyyy")]
        [DataType(DataType.Date)]
        public DateTime DateTimeAdded { get; set; }
        public bool IsPublished { get; set; }
        public CodeSnippetViewModel(CodeSnippetModel model, MemberRepository repository)
        {
            this.IdcodeSnippet = model.IdcodeSnippet;
            this.Title = model.Title;
            this.ContentCode = model.ContentCode;
            this.Idmember = model.Idmember;
            this.Revision = model.Revision;
            this.IdsnippetPreviousVersion = model.IdsnippetPreviousVersion;
            this.DateTimeAdded = model.DateTimeAdded;
            this.IsPublished = model.IsPublished;
            var member = repository.GetMemberById(model.Idmember);
            this.MemberName = member.Name;
        }
    }
}
