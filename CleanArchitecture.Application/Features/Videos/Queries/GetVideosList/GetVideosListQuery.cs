using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Videos.Queries.GetVideosList
{
    public class GetVideosListQuery : IRequest<List<VideosVm>>
    {
        public string Username { get; set; } = String.Empty;
        public GetVideosListQuery(string _Username) { 
            Username = _Username ?? throw new ArgumentNullException(nameof(_Username));
        }
    }
}
