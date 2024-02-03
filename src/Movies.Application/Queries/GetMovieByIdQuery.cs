﻿using MediatR;
using Movies.Contracts;
using Movies.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.Application.Queries
{
    public record GetMovieByIdQuery(int Id) : IRequest<GetMovieByIdResponse> { }
}
