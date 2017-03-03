//
//  MDPPlaylistModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

#import "_MDPPlaylistModel.h"


#pragma mark - Interface
@interface MDPPlaylistModel : _MDPPlaylistModel

+ (instancetype)playlistWithId:(NSString *)playlistId managedObjectContext:(NSManagedObjectContext *)context;

+ (instancetype)insertWithDictionary:(NSDictionary *)dictionary managedObjectContext:(NSManagedObjectContext *)context;

/*
 Returns the PlayList with idPlaylist or all the Playlist if it's nill
 */
+ (NSFetchedResultsController *)playlistFetchedResultsControllerWithIdPlaylist:(NSString *)idPlaylist managedObjectContext:(NSManagedObjectContext *)context delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

+ (NSFetchedResultsController *)playlistFetchedResultsControllerWithPlaylistName:(NSString *)name managedObjectContext:(NSManagedObjectContext *)context delegate:(id <NSFetchedResultsControllerDelegate>)delegate;

@end
