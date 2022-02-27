﻿namespace Blogify.GraphQL.Configuration;

public class GraphQLErrorFilter: IErrorFilter
{
    public IError OnError(IError error)
    {
        return error
            .WithMessage(error.Exception.Message)
            .WithCode(GraphQLError.WrongInput);
    }
}