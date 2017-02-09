//
//  MDPMatchesHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 23/1/15.
//  Copyright (c) 2015 Microsoft. All rights reserved.
//

#ifndef MDPClient_MDPMatchesHandlerProtocol_h
#define MDPClient_MDPMatchesHandlerProtocol_h

#pragma mark - Model
#import "MDPMatchModel.h"
#import "MDPTimelineModel.h"
#import "MDPPagedMatchSubscriptionInformationModel.h"
#import "MDPPagedFavoriteMatchModel.h"
#import "MDPVideoAdInformationModel.h"
#import "MDPFavoriteModel.h"


#pragma mark VideoAdType
typedef NS_ENUM(NSUInteger, MDPMatchesVideoAdType) {
    MDPMatchesVideoAdTypePreroll    =   0,
    MDPMatchesVideoAdTypePostroll   = 1,
};


#pragma mark MatchesAssetVideoType
typedef NS_ENUM(NSUInteger, MDPMatchesAssetVideoType) {
    MDPMatchesAssetVideoTypeProgressive         = 0,
    MDPMatchesAssetVideoTypeHDS                 = 1,
    MDPMatchesAssetVideoTypeHLS                 = 2,
    MDPMatchesAssetVideoTypeSmoothStreaming     = 3,
};


#pragma mark - Response
typedef void (^MDPMatchesHandlerResponseBlock)(NSArray *response, NSError *error);

#pragma mark - MDPMatchesHandlerProtocol
@protocol MDPMatchesHandlerProtocol <NSObject>


/*
 Get the timeline of a match. A timeline is identified by two fields: id of the match and language for the timeline.
 */
+ (void)getMatchTimelineWithIdSeason:(NSString *)idSeason
                       idCompetition:(NSString *)idCompetition
                             idMatch:(NSString *)idMatch
                            language:(NSString *)language
                     completionBlock:(void (^)(MDPTimelineModel *content, NSError *error))completionBlock;

/*
Get all the Master Data for a sport type and language.
 */
+ (void)getMasterDataBySportWithSportType:(MDPMatchModelSportType)sportType
                          completionBlock:(MDPMatchesHandlerResponseBlock)completionBlock;

/*
 Get a match. A match is identified by three fields: id of the season, id of the competition and id of the match.
 */
+ (void)getMatchWithIdSeason:(NSString *)idSeason
               idCompetition:(NSString *)idCompetition
                     idMatch:(NSString *)idMatch
                    language:(NSString *)language
                     country:(NSString *)country
             completionBlock:(void (^)(MDPMatchModel *content, NSError *error))completionBlock;

/*
 Gets for a specific match and country its related advertisement
 */
+ (void)getMatchVideoAdWithIdSeason:(NSString *)idSeason
                      idCompetition:(NSString *)idCompetition
                            idMatch:(NSString *)idMatch
                            country:(NSString *)country
                        videoAdType:(MDPMatchesVideoAdType)videoAdType
                          videoType:(MDPMatchesAssetVideoType)videoType
                    completionBlock:(void (^)(MDPVideoAdInformationModel *content, NSError *error))completionBlock;

/*
 Gets all the match subscriptions.The results are returned paginated.
 */
+ (void)getAllSubscriptionsPagedWithCt:(NSInteger)ct
                       completionBlock:(void (^)(MDPPagedMatchSubscriptionInformationModel *content, NSError *error))completionBlock;

/*
 Gets Authorization token for the requested video of the match
 */
+ (void)getMatchCDNTokenAsyncWithIdSeason:(NSString *)idSeason
                            idCompetition:(NSString *)idCompetition
                                  idMatch:(NSString *)idMatch
                                videoType:(NSString *)videoType
                                 videoURL:(NSString *)videoURL
                          completionBlock:(void (^)(NSString *content, NSError *error))completionBlock;

/*
 Gets if the authorization token for the requested video type of the match is available
 */
+ (void)isMatchCDNTokenAvailableAsyncWithIdSeason:(NSString *)idSeason
                                    idCompetition:(NSString *)idCompetition
                                          idMatch:(NSString *)idMatch
                                        videoType:(NSString *)videoType
                                          country:(NSString *)country
                                  completionBlock:(void (^)(BOOL content, NSError *error))completionBlock;

/*
 Add match as part of user's favorite matches
 */
+ (void)postFavoriteMatchWithIdSeason:(NSString *)idSeason
                        idCompetition:(NSString *)idCompetition
                              idMatch:(NSString *)idMatch
                      completionBlock:(void (^)(NSError *error))completionBlock;

/*
 Remove match as part of user's favorite matches
 */
+ (void)deleteFavoriteMatchWithIdSeason:(NSString *)idSeason
                          idCompetition:(NSString *)idCompetition
                                idMatch:(NSString *)idMatch
                        completionBlock:(void (^)(NSError *error))completionBlock;

/*
 Gets the list of paginated user's favorite matches
 */
+ (void)getPagedFavoriteMatchWithPageSize:(NSNumber *)pageSize
                                 language:(NSString *)language
                                       ct:(NSString *)ct
                          completionBlock:(void (^)(MDPPagedFavoriteMatchModel *content, NSError *error))completionBlock;

/*
 Gets the requested advertisements types for a given match on VMAP form
 */
+ (void)getMatchVideoAdsVmapXmlWithIdSeason:(NSString *)idSeason
                              idCompetition:(NSString *)idCompetition
                                    idMatch:(NSString *)idMatch
                                    country:(NSString *)country
                                videoAdType:(uint)videoAdType
                                  videoType:(uint)videoType
                            completionBlock:(void (^)(NSString *url, NSString *, NSError *error))completionBlock;

/*
 Get user's favorite match by identifier
 */
+ (void)getFavoriteMatchWithIdSeason:(NSString *)idSeason
                       idCompetition:(NSString *)idCompetition
                             idMatch:(NSString *)idMatch
                     completionBlock:(void (^)(MDPFavoriteModel *content, NSError *error))completionBlock;


#pragma mark - Delete all Favorite Matches
+ (void)deleteAllFavoriteMatches;


#pragma mark - Fetchs
+ (NSFetchedResultsController *)favoriteMatchesFetchedResultsControllerDelegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end

#endif












































































