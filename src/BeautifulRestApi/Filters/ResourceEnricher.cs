﻿using System;
using BeautifulRestApi.Models;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Routing;

namespace BeautifulRestApi.Filters
{
    public class ResourceEnricher : AbstractResultEnricher<Resource>
    {
        private readonly IUrlHelperFactory _urlHelperFactory;

        public ResourceEnricher(IUrlHelperFactory urlHelper)
        {
            _urlHelperFactory = urlHelper;
        }

        protected override void OnEnriching(ResultExecutingContext context, Resource result, Action<ResultExecutingContext, object> enrichChildAction)
        {
            var linkRewriter = new LinkRewriter(_urlHelperFactory.GetUrlHelper(context));

            result.Meta = linkRewriter.Rewrite(result.Meta);
        }
    }
}