﻿using BeatLeader_Server.Models;
using static BeatLeader_Server.Services.SearchService;

namespace BeatLeader_Server.Utils;

public enum Operation {
    any = 0,
    all = 1,
    not = 2,
}

public static partial class MapListUtils {
    public static IQueryable<Leaderboard> Filter(this IQueryable<Leaderboard> source,
                                                 ReadAppContext context,
                                                 int page,
                                                 int count,
                                                 ref int searchCount, 
                                                 string? sortBy = null,
                                                 string? order = null,
                                                 string? search = null,
                                                 string? type = null,
                                                 string? mode = null,
                                                 int? mapType = null,
                                                 Operation allTypes = 0,
                                                 Requirements? mapRequirements = null,
                                                 Operation allRequirements = 0,
                                                 string? mytype = null,
                                                 float? stars_from = null,
                                                 float? stars_to = null,
                                                 float? accrating_from = null,
                                                 float? accrating_to = null,
                                                 float? passrating_from = null,
                                                 float? passrating_to = null,
                                                 float? techrating_from = null,
                                                 float? techrating_to = null,
                                                 int? date_from = null,
                                                 int? date_to = null,
                                                 string? currentID = null) {

        List<SongMatch>? matches = null;

        var filtered = source
               .FilterBySearch(ref matches, search)
               .WhereType(type)
               .WhereMapType(mapType, allTypes)
               .WhereMode(mode)
               .WhereMapRequirements(mapRequirements, allRequirements)
               .WhereMyType(context, mytype, currentID)

               .WhereRatingFrom(RatingType.Stars, stars_from)
               .WhereRatingFrom(RatingType.Acc, accrating_from)
               .WhereRatingFrom(RatingType.Pass, passrating_from)
               .WhereRatingFrom(RatingType.Tech, techrating_from)

               .WhereRatingTo(RatingType.Stars, stars_to)
               .WhereRatingTo(RatingType.Acc, accrating_to)
               .WhereRatingTo(RatingType.Pass, passrating_to)
               .WhereRatingTo(RatingType.Tech, techrating_to);

        if (matches != null) {
            var matchedAndFiltered = filtered.Select(p => p.Id).ToList();
            searchCount = matchedAndFiltered.Count;
            var sorted = matchedAndFiltered
                .OrderByDescending(p => matches.FirstOrDefault(m => m.Id == p)?.Score ?? 0)
                .Skip((page - 1) * count)
                .Take(count)
                .ToList();

            return filtered.Where(p => sorted.Contains(p.Id));
        } else {
            return filtered.Sort(sortBy, order!, type, mytype, date_from, date_to, currentID);
        }
    }
}