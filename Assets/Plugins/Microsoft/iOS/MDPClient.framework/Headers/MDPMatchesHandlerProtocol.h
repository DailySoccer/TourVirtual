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
+ (void)getMatchVideoAdXmlWithIdSeason:(NSString *)idSeason
                         idCompetition:(NSString *)idCompetition
                               idMatch:(NSString *)idMatch
                               country:(NSString *)country
                           videoAdType:(MDPMatchesVideoAdType)videoAdType
                             videoType:(MDPMatchesAssetVideoType)videoType
                       completionBlock:(void (^)(NSString *content, NSError *error))completionBlock;

@end

#endif
