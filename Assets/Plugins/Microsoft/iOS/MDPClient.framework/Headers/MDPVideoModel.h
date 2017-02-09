//
//  MDPVideoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPVideoModel.h"


#pragma mark Content Types
typedef NS_ENUM(NSUInteger, MDPVideoModelCallType) {
    MDPVideoModelCallTypeVideos                                     = 1,
    MDPVideoModelCallTypeVideosById                                 = 2,
    MDPVideoModelCallTypegBySeasonCompetitionAndMatch               = 3,
    MDPVideoModelCallTypeVideosBySearchText                         = 4,
    MDPVideoModelCallTypeMoreLikeThis                               = 5,
    MDPVideoModelCallTypeHighlightedVideos                          = 6,
    MDPVideoModelCallTypeSearchVideosByCriteria                     = 7,
    MDPVideoModelCallTypeMostPlayedVideos                           = 8,
    MDPVideoModelCallTypeMostSearchedVideos                         = 9,
    MDPVideoModelCallTypeMostValuedVideos                           = 10,
    MDPVideoModelCallTypeRecommendedVideos                          = 11,
    MDPVideoModelCallTypeBygeolocation                              = 12,
    MDPVideoModelCallTypeMostRecentVideos                           = 13,
    MDPVideoModelCallTypeVideoPlayList                              = 14,
    MDPVideoModelCallTypeSubscriptionVideos                         = 15,
};


#pragma mark - Interface
@interface MDPVideoModel : _MDPVideoModel

+ (NSArray *)videosWithCallType:(MDPVideoModelCallType)callType managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertIfNotExistsVideosWithCallType:(MDPVideoModelCallType)callType
                                         dictionary:(NSDictionary *)dictionary
                               managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertWithIdPlayList:(NSString *)idPlaylist
                          dictionary:(NSDictionary *)dictionary
                managedObjectContext:(NSManagedObjectContext *)context;

+ (MDPVideoModel *)videosWithIdVideo:(NSString *)idVideo
                managedObjectContext:(NSManagedObjectContext *)context;

+ (MDPVideoModel *)videoWithIdPlaylist:(NSString *)idPlaylist
                               idVideo:(NSString *)idVideo
                  managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertWithIdSubscription:(NSString *)idSubscription
                              dictionary:(NSDictionary *)dictionary
                    managedObjectContext:(NSManagedObjectContext *)context;

+ (NSArray *)videosWithIdPlaylist:(NSString *)idPlaylist
            managedObjectContext:(NSManagedObjectContext *)context;



//+ (NSArray *)videosWithManagedObjectContext:(NSManagedObjectContext *)context;

/*+ (NSArray *)videosWithIdSeason:(NSString *)idSeason
                  idCompetition:(NSString *)idCompetition
                        idMatch:(NSString *)idMatch
           managedObjectContext:(NSManagedObjectContext *)context;
 

+ (instancetype)insertIfNotExistsVideosWithIdSeason:(NSString *)idSeason
                                      idCompetition:(NSString *)idCompetition
                                            idMatch:(NSString *)idMatch
                                         dictionary:(NSDictionary *)dictionary
                               managedObjectContext:(NSManagedObjectContext *)context;*/


- (NSArray *)videoTypesString;

+ (NSFetchedResultsController *)videosFetchedResultsControllerWithIdPlaylist:(NSString *)idPlaylist
                                                        managedObjectContext:(NSManagedObjectContext *)context
                                                                    delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)videosFetchResultsControllerWithIdSubscription:(NSString *)idSubscription
                                                          managedObjectContext:(NSManagedObjectContext *)context
                                                                      delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)videosFetchedResultsControllerWithIdsSubscription:(NSArray *)idsSubscription
                                                             managedObjectContext:(NSManagedObjectContext *)context
                                                                         delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end






































































