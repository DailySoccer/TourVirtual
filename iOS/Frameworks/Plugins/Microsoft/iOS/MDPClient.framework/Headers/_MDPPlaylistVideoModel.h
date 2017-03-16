//
//  _MDPPlaylistVideoModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPlaylistVideoModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPlaylistVideoModelAttributes {
	__unsafe_unretained NSString *creationDate;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *videoId;
} MDPPlaylistVideoModelAttributes;

extern const struct MDPPlaylistVideoModelRelationships {
	__unsafe_unretained NSString *playlistVideos;
} MDPPlaylistVideoModelRelationships;

@class MDPPlaylistModel;

@interface _MDPPlaylistVideoModel : NSManagedObject

@property (nonatomic, strong) NSDate* creationDate;

//- (BOOL)validateCreationDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* videoId;

//- (BOOL)validateVideoId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPlaylistModel *playlistVideos;

//- (BOOL)validatePlaylistVideos:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPPlaylistVideoModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveCreationDate;
- (void)setPrimitiveCreationDate:(NSDate*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveVideoId;
- (void)setPrimitiveVideoId:(NSString*)value;

- (MDPPlaylistModel*)primitivePlaylistVideos;
- (void)setPrimitivePlaylistVideos:(MDPPlaylistModel*)value;

@end
