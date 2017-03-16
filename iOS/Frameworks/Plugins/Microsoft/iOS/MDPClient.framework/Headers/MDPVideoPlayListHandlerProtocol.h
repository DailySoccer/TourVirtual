//
//  MDPVideoPlayListHandlerProtocol.h
//  MDPClient
//
//  Created by Luis Paez Gonzalez on 16/8/16.
//  Copyright © 2016 Microsoft. All rights reserved.
//

#ifndef MDPVideoPlayListHandlerProtocol_h
#define MDPVideoPlayListHandlerProtocol_h


#import "MDPPagedVideoPlaylistModel.h"
#import "MDPPagedVideosModel.h"
#import "MDPPlaylistModel.h"


#pragma mark - Response
typedef void (^MDPVideoPlayListHandlerResponseBlock)(NSArray *response, NSError *error);



#pragma mark - MDPVideoPlayListHandlerProtocol
@protocol MDPVideoPlayListHandlerProtocol <NSObject>

/*
 Gets the paginated lists of PlayList for a current user
 */
+ (void)getVideoPlaylistsWithCt:(NSString *)ct completionBlock:(void(^)(MDPPagedVideoPlaylistModel *content, NSError *error))completionBlock;

/*
 Sends to platform the PlayList of a current user
 */
+ (void)postPlaylistWithName:(NSString *)name videoIds:(NSArray *)videoIds completionBlock:(void(^)(NSString *playlistId, NSError *error))completionBlock;

/*
 Gets the paginated videos for a playList by its playlistId
 */

+ (void)getVideoPlaylistVideosWithPlayListId:(NSString *)playListId top:(NSNumber *)top skip:(NSNumber *)skip completionBlock:(void(^)(MDPPagedVideosModel *content, NSError *error))completionBlock;

/*
 Updates in platform the PlayList of a current user by its playlistId
 */
+ (void)putVideoPlaylistWithId:(NSString *)idPlayList name:(NSString *)name completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Deletes in platform a PlayList by its playlistId
 */
+ (void)deleteVideoPlaylistWithPlaylistId:(NSString *)playlistId completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Deletes in platform a video of a playlist by its videoId and playlistId
 */
+ (void)deleteVideoPlaylistWithPlaylistId:(NSString *)playlistId videoId:(NSString *)videoId completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Add in platform a video in a playlist by playListId and videoId
 */
+ (void)postVideoInPlaylistWithPlaylistId:(NSString *)playlistId videoId:(NSString *)videoId completionBlock:(void(^)(NSError *error))completionBlock;

/*
 Gets the Playlist by its Id
 */
+ (void)getVideoPlaylistWithId:(NSString *)playlistId completionBlock:(void(^)(MDPPlaylistModel *content, NSError *error))completionBlock;

/*
 Gets all video playlists for the current user, ordered as specified in "orderBy" param.
 */
+ (void)getAllVideoPlaylistsWithOrderByCreationDateAscending:(BOOL)ascending completionBlock:(MDPVideoPlayListHandlerResponseBlock)completionBlock;


/*
 FetchedResultsController
 Returns the PlayList with idPlaylist or all the Playlist if it's nill
 */
+ (NSFetchedResultsController *)playlistFetchedResultsControllerWithIdPlaylist:(NSString *)idPlaylist delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

/*
 Returns the Playlist videos, it returns nil if idPlaylist is nil.
 */
+ (NSFetchedResultsController *)videosFetchedResultsControllerWithIdPlaylist:(NSString *)idPlaylist delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

/*
 Delete Request, Paged, Playlist, PlaylistVideo and Videos relational with Playlist in database
 */
+ (void)deleteCachePlaylist;

@end

#endif
