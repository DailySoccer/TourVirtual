//
//  MDPVideoHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 30/3/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPVideoHandlerProtocol_h
#define MDPClient_MDPVideoHandlerProtocol_h


#import "MDPPagedSubscriptionConfigurationBasicInfoModel.h"
#import "MDPPagedVideosModel.h"
#import "MDPVideoModel.h"


#pragma mark  - Response
typedef void (^MDPVideoHandlerResponseBlock)(NSArray *response, NSError *error);


#pragma mark - MDPVideoHandlerProtocol
@protocol MDPVideoHandlerProtocol <NSObject>

/*
  Get all videos
 */
+ (void)getVideosWithTop:(NSInteger)top
                    skip:(NSInteger)skip
                   count:(BOOL)count
         completionBlock:(MDPVideoHandlerResponseBlock)completionBlock;

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
                                count:(BOOL)count
                      completionBlock:(void(^)(MDPPagedVideosModel *content, NSError *error))completionBlock;

/*
 Gets the more like this.
 */
+ (void)getMoreLikeThisWithId:(NSString *)identifier
                          top:(NSInteger)top
                         skip:(NSInteger)skip
                        count:(BOOL)count
              completionBlock:(void(^)(MDPPagedVideosModel *content, NSError *error))completionBlock;

/*
 Gets the highlighted videos
 */
+ (void)getHighlightedVideosWithCountry:(NSString *)country
                                 idType:(NSString *)idType
                                     ct:(NSInteger)ct
                               language:(NSString *)language
                        completionBlock:(void(^)(MDPPagedVideosModel *content, NSError *error))completionBlock;

/*
 Gets the videos by search criteria.
 
 MainActors: Collection of string
 MatchEventTypes: Collection of string
 */
+ (void)searchVideosByCriteriaWithCompetition:(NSString *)competition
                                          season:(NSString *)season
                                      mainActors:(NSArray *)mainActors
                                 matchEventTypes:(NSArray *)matchEventTypes
                                             top:(NSInteger)top
                                            skip:(NSInteger)skip
                                   searchText:(NSString *)searchText
                                 completionBlock:(MDPVideoHandlerResponseBlock)completionBlock;

/*
 Get the most played videos
 */
+ (void)getMostPlayedVideosWithTop:(NSInteger)top
                              skip:(NSInteger)skip
                             count:(BOOL)count
                   completionBlock:(void(^)(MDPPagedVideosModel *content, NSError *error))completionBlock;

/*
 Get the most searched videos
 */
+ (void)getMostSearchedVideosWithTop:(NSInteger)top
                                skip:(NSInteger)skip
                               count:(BOOL)count
                     completionBlock:(void(^)(MDPPagedVideosModel *content, NSError *error))completionBlock;

/*
 Gets the most valued videos.
 */
+ (void)getMostValuedVideosWithTop:(NSInteger)top
                              skip:(NSInteger)skip
                             count:(BOOL)count
                   completionBlock:(void(^)(MDPPagedVideosModel *content, NSError *error))completionBlock;

/*
 Gets the virtual tickets by search metadata.
 */
+ (void)getVirtualTicketsBySearchMetadataWithIdSeason:(NSString *)idSeason
                                        idCompetition:(NSString *)idCompetition
                                                title:(NSString *)title
                                             language:(NSString *)language
                                                  top:(NSInteger)top
                                                 skip:(NSInteger)skip
                                                count:(BOOL)count
                                      completionBlock:(void(^)(MDPPagedSubscriptionConfigurationBasicInfoModel *content, NSError *error))completionBlock;

/*
 Gets the video packs by search metadata.
 */
+ (void)searchVideoPackByMetadataWithSeason:(NSString *)season
                            videoTypes:(NSArray *)videoTypes
                            matchEventTypes:(NSArray *)matchEventTypes
                            competitionType:(NSString *)competitionType
                                 mainActors:(NSArray *)mainActors
                                   language:(NSString *)language
                                        top:(NSInteger)top
                                       skip:(NSInteger)skip
                            completionBlock:(void(^)(MDPPagedSubscriptionConfigurationBasicInfoModel *content, NSError *error))completionBlock;

/*
 Gets the videos recommended to the user
 */
+ (void)getRecommendedVideosWithTop:(NSInteger)top
                               skip:(NSInteger)skip
                              count:(BOOL)count
                    completionBlock:(void(^)(MDPPagedVideosModel *content, NSError *error))completionBlock;

/*
 Gets videos by proximity to geographic coordinates
 */
+ (void)getVideosByGeolocationWithLatitude:(NSDecimalNumber *)latitude
                                 longitude:(NSDecimalNumber *)longitude
                                         z:(NSDecimalNumber *)z
                                       top:(NSInteger)top
                                      skip:(NSInteger)skip
                           completionBlock:(void(^)(MDPPagedVideosModel *content, NSError *error))completionBlock;

/*
 Gets the videos recommended to the user
 */
+ (void)getMostRecentVideosWithTop:(NSInteger)top
                              skip:(NSInteger)skip
                   completionBlock:(void(^)(MDPPagedVideosModel *content, NSError *error))completionBlock;

@end

#endif











































