using MediatR;
using Movies.Infrastructure;

using Movies.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Movies.Application.Commands
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand,Unit>
    {
        public readonly MovieDbContext _movieDbContext;
        public DeleteMovieCommandHandler(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public async Task<Unit> Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
        {
           
          var MovieToDelete =  await _movieDbContext.Movies.FirstOrDefaultAsync(movie=> movie.Id==request.Id,cancellationToken);
          
            if(MovieToDelete is null)
            {
                throw new Exception();
            } 
            _movieDbContext.Movies.Remove(MovieToDelete);
            await _movieDbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }

    }
}
