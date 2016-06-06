//
//  MDPCalendarServiceProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 22/1/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPCalendarHandlerProtocol_h
#define MDPClient_MDPCalendarHandlerProtocol_h

#import "MDPCompetitionMatchModel.h"
#import "MDPCompetitionModel.h"
#import "MDPMatchStatusModel.h"

#pragma mark  - Response
typedef void (^MDPCalendarHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPCalendarHandlerProtocol
@protocol MDPCalendarHandlerProtocol <NSObject>

/*
 Gets the calendar for a competition, season and a Team.
 A calendar is identified for a competition, a season
 */
+ (void)getCalendarWithIdSeason:(NSString *)idSeason
                  idCompetition:(NSString *)idCompetition
                         idTeam:(NSString *)idTeam
                       language:(NSString *)language
                        country:(NSString *)country
                completionBlock:(MDPCalendarHandlerResponseBlock)completionBlock;

/*
 Gets the next match for a team
 The match is identified for a team
 */
+ (void)getNextMatchWithIdTeam:(NSString *)idTeam
               numberOfMatches:(uint)numberOfMatches
                     sportType:(MDPCompetitionMatchModelSportType)sportType
                      language:(NSString *)language
                       country:(NSString *)country
               completionBlock:(MDPCalendarHandlerResponseBlock)completionBlock;

/*
 Gets the next match status for a team.
 */
+ (void)getNextMatchStatusWithIdTeam:(NSString *)idTeam
                           sportType:(MDPMatchStatusModelSportType)sportType
                            language:(NSString *)language
                     completionBlock:(void(^)(MDPMatchStatusModel *content, NSError *error))completionBlock;

/*
 Gets the last finished match for a team.Gets the last finished match for a team.
 */
+ (void)getPreviousMatchWithIdTeam:(NSString *)idTeam
                         sportType:(MDPCompetitionMatchModelSportType)sportType
                          language:(NSString *)language
                     includeRecent:(BOOL)includeRecent
                           country:(NSString *)country
                   completionBlock:(void(^)(MDPCompetitionMatchModel *content, NSError *error))completionBlock;


/*
 Gets the standing for a competition and a season.
 */
+ (void)getStandingWithIdSeason:(NSString *)idSeason
                  idCompetition:(NSString *)idCompetition
                       matchDay:(NSString *)matchDay
                        idGroup:(NSString *)idGroup
                       language:(NSString *)language
                completionBlock:(MDPCalendarHandlerResponseBlock)completionBlock;

/*
 Gets the competitions played by a team during a season.
 */
+ (void)getCompetitionsByTeamWithIdSeason:(NSString *)idSeason
                                   idTeam:(NSString *)idTeam
                                 language:(NSString *)language
                          completionBlock:(MDPCalendarHandlerResponseBlock)completionBlock;

/*
 Gets the competition details.
 */
+ (void)getCompetitionWithIdCompetition:(NSString *)idCompetition
                        completionBlock:(void(^)(MDPCompetitionModel *content, NSError *error))completionBlock;


/*
 Gets a list of matches of a competition by match day
 */
+ (void)getCompetitionCalendarByMatchDayWithIdSeason:(NSString *)idSeason
                                       idCompetition:(NSString *)idCompetition
                                            language:(NSString *)language
                                            matchDay:(NSString *)matchDay
                                              idTeam:(NSString *)idTeam
                                             country:(NSString *)country
                                     completionBlock:(MDPCalendarHandlerResponseBlock)completionBlock;

/*
 Gets a list of matches of a competition by round
 */
+ (void)getCompetitionCalendarByRoundWithIdSeason:(NSString *)idSeason
                                    idCompetition:(NSString *)idCompetition
                                         language:(NSString *)language
                                            round:(NSString *)round
                                           idTeam:(NSString *)idTeam
                                          country:(NSString *)country
                                  completionBlock:(MDPCalendarHandlerResponseBlock)completionBlock;

/*
 Gets a list of all match days available for a competition.
 */
+ (void)getMatchDaysWithIdSeason:(NSString *)idSeason
                   idCompetition:(NSString *)idCompetition
                          idTeam:(NSString *)idTeam
                 completionBlock:(MDPCalendarHandlerResponseBlock)completionBlock;

/*
 Gets a list of stages for a competition.
 */
+ (void)getStagesWithIdSeason:(NSString *)idSeason
                idCompetition:(NSString *)idCompetition
                    sportType:(MDPCompetitionMatchModelSportType)sportType
                       idTeam:(NSString *)idTeam
                     language:(NSString *)language
              completionBlock:(MDPCalendarHandlerResponseBlock)completionBlock;

/*
 Gets the calendar for a team between to dates.
 */
+ (void)getMatchesByDateRangeWithFrom:(NSDate *)from
                                   to:(NSDate *)to
                               idTeam:(NSString *)idTeam
                            sportType:(MDPCompetitionMatchModelSportType)sportType
                             language:(NSString *)language
                              country:(NSString *)country
                      completionBlock:(MDPCalendarHandlerResponseBlock)completionBlock;

/*
 Gets the last finished matches for a team.
 */
+ (void)getLastPlayedMatchesWithIdTeam:(NSString *)idTeam
                             sportType:(NSInteger)sportType
                              language:(NSString *)language
                         includeRecent:(BOOL)includeRecent
                               country:(NSString *)country
                       numberOfMatches:(NSInteger)numberOfMatches
                       completionBlock:(MDPCalendarHandlerResponseBlock)completionBlock;


/*
 Fetch CompetitionMatch for one date
 */

+ (NSArray *)fetchCompetitionMatchWithIdSeason:(NSString *)idSeason
                                 idCompetition:(NSString *)idCompetition
                                         month:(NSDate *)date;
+ (NSArray *)fetchCompetitionMatchWithIdSeason:(NSString *)idSeason
                                 idCompetition:(NSString *)idCompetition
                                         month:(NSDate *)date
                                        idTeam:(NSString *)idTeam;

/*
 Fetch CompetitionMatch for one team
 */
+ (NSArray *)fetchCompetitionMatchWithIdSeason:(NSString *)idSeason
                                 idCompetition:(NSString *)idCompetition
                                        idTeam:(NSString *)idTeam;

+ (NSArray *)fetchCompetitionMatchWithIdSeason:(NSString *)idSeason
                                 idCompetition:(NSString *)idCompetition
                                        idTeam:(NSString *)idTeam
                                oppositeIdTeam:(NSString *)oppositeIdTeam;

/*
 Fetch Competitions for one team
 */

+ (NSArray *)fetchCompetitionsWithIdSeason:(NSString *)idSeason
                                    idTeam:(NSString *)idTeam;

/*
 Fetch Standings
 */

+ (NSArray *)fetchStandingWithIdSeason:(NSString *)idSeason
                         idCompetition:(NSString *)idCompetition
                              matchDay:(NSString *)matchDay
                               idGroup:(NSString *)idGroup;

+ (NSArray *)fetchStandingWithIdSeason:(NSString *)idSeason
                         idCompetition:(NSString *)idCompetition
                              matchDay:(NSString *)matchDay;

+ (NSFetchedResultsController *)standingItemsFetchedResultsControllerWithIdSeason:(NSString *)idSeason
                                                                    idCompetition:(NSString *)idCompetition
                                                                         matchDay:(NSString *)matchDay
                                                                          idGroup:(NSString *)idGroup
                                                                         delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end

#endif






































































