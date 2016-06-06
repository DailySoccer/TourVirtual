//
//  MDPVideoHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 30/3/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPVideoHandlerProtocol_h
#define MDPClient_MDPVideoHandlerProtocol_h

#import "MDPVideoModel.h"


#pragma mark  - Response
typedef void (^MDPVideoHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPVideoHandlerProtocol
@protocol MDPVideoHandlerProtocol <NSObject>

/*
  Get all videos
 */
+ (void)getVideosWithCompletionBlock:(MDPVideoHandlerResponseBlock)completionBlock;

/*
  Gets a video identified by his id
 */
+ (void)getVideosByIdWithIdVideo:(NSString *)idVideo
                 completionBlock:(void(^)(MDPVideoModel *content, NSError *error))completionBlock;

/*
 Get the videos identified by idSeason, idCompetition and idMatch
 */
+ (void)getVideosBySeasonCompetitionAndMatchWithIdSeason:(NSString *)idSeason
                                           idCompetition:(NSString *)idCompetition
                                                 idMatch:(NSString *)idMatch
                                         completionBlock:(MDPVideoHandlerResponseBlock)completionBlock;

/*
 Automatics the complete.
 */
+ (void)autoCompleteWithText:(NSString *)text
                         top:(NSInteger)top
                        skip:(NSInteger)skip
             completionBlock:(MDPVideoHandlerResponseBlock)completionBlock;

/*
 Gets the videos by search text.
 */
+ (void)getVideosBySearchTextWithText:(NSString *)text
                                  top:(NSInteger)top
                                 skip:(NSInteger)skip
                      completionBlock:(MDPVideoHandlerResponseBlock)completionBlock;

/*
 Gets the more like this.
 */
+ (void)getMoreLikeThisWithId:(NSString *)identifier
                          top:(NSInteger)top
                         skip:(NSInteger)skip
              completionBlock:(MDPVideoHandlerResponseBlock)completionBlock;

/*
 Gets the highlighted videos
 */
+ (void)getHighlightedVideosWithCountry:(NSString *)country
                                 idType:(NSString *)idType
                               language:(NSString *)language
                        completionBlock:(MDPVideoHandlerResponseBlock)completionBlock;

/*
 Gets the videos by search criteria.
 */
+ (void)getVideosBySearchCriteriaWithCompetition:(NSString *)competition
                                          season:(NSString *)season
                                      mainActors:(NSArray *)mainActors
                                 matchEventTypes:(NSArray *)matchEventTypes
                                             top:(NSInteger)top
                                            skip:(NSInteger)skip
                                 completionBlock:(MDPVideoHandlerResponseBlock)completionBlock;

/*
 Get the most played videos
 */
+ (void)getMostPlayedVideosWithTop:(NSInteger)top
                              skip:(NSInteger)skip
                   completionBlock:(MDPVideoHandlerResponseBlock)completionBlock;

/*
 Get the most searched videos
 */
+ (void)getMostSearchedVideosWithTop:(NSInteger)top
                                skip:(NSInteger)skip
                     completionBlock:(MDPVideoHandlerResponseBlock)completionBlock;

/*
 */
+ (void)getMostValuedVideosWithTop:(NSInteger)top
                              skip:(NSInteger)skip
                   completionBlock:(MDPVideoHandlerResponseBlock)completionBlock;

@end

#endif
