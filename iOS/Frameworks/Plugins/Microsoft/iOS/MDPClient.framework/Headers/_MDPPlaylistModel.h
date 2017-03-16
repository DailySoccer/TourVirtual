//
//  _MDPPlaylistModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPlaylistModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPlaylistModelAttributes {
	__unsafe_unretained NSString *creationDate;
	__unsafe_unretained NSString *idPlayList;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *videosCount;
} MDPPlaylistModelAttributes;

extern const struct MDPPlaylistModelRelationships {
	__unsafe_unretained NSString *pagedVideoPlaylist;
	__unsafe_unretained NSString *videos;
} MDPPlaylistModelRelationships;

@class MDPPagedVideoPlaylistModel;
@class MDPPlaylistVideoModel;

@interface _MDPPlaylistModel : NSManagedObject

@property (nonatomic, strong) NSDate* creationDate;

//- (BOOL)validateCreationDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idPlayList;

//- (BOOL)validateIdPlayList:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* videosCount;

@property (atomic) int64_t videosCountValue;
- (int64_t)videosCountValue;
- (void)setVideosCountValue:(int64_t)value_;

//- (BOOL)validateVideosCount:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPagedVideoPlaylistModel *pagedVideoPlaylist;

//- (BOOL)validatePagedVideoPlaylist:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *videos;

- (NSMutableSet*)videosSet;

@end

@interface _MDPPlaylistModel (VideosCoreDataGeneratedAccessors)
- (void)addVideos:(NSSet*)value_;
- (void)removeVideos:(NSSet*)value_;
- (void)addVideosObject:(MDPPlaylistVideoModel*)value_;
- (void)removeVideosObject:(MDPPlaylistVideoModel*)value_;
@end

@interface _MDPPlaylistModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveCreationDate;
- (void)setPrimitiveCreationDate:(NSDate*)value;

- (NSString*)primitiveIdPlayList;
- (void)setPrimitiveIdPlayList:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSNumber*)primitiveVideosCount;
- (void)setPrimitiveVideosCount:(NSNumber*)value;

- (int64_t)primitiveVideosCountValue;
- (void)setPrimitiveVideosCountValue:(int64_t)value_;

- (MDPPagedVideoPlaylistModel*)primitivePagedVideoPlaylist;
- (void)setPrimitivePagedVideoPlaylist:(MDPPagedVideoPlaylistModel*)value;

- (NSMutableSet*)primitiveVideos;
- (void)setPrimitiveVideos:(NSMutableSet*)value;

@end
