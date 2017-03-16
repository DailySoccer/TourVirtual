//
//  _MDPFriendTimelineModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPFriendTimelineModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPFriendTimelineModelAttributes {
	__unsafe_unretained NSString *alias;
	__unsafe_unretained NSString *avatarThumbnailUrl;
	__unsafe_unretained NSString *avatarUrl;
	__unsafe_unretained NSString *idUserFriend;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
} MDPFriendTimelineModelAttributes;

extern const struct MDPFriendTimelineModelRelationships {
	__unsafe_unretained NSString *pagedFriendTimeline;
	__unsafe_unretained NSString *timeLine;
} MDPFriendTimelineModelRelationships;

@class MDPPagedFriendTimelineModel;
@class MDPUserActionHistoryModel;

@interface _MDPFriendTimelineModel : NSManagedObject

@property (nonatomic, strong) NSString* alias;

//- (BOOL)validateAlias:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* avatarThumbnailUrl;

//- (BOOL)validateAvatarThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* avatarUrl;

//- (BOOL)validateAvatarUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUserFriend;

//- (BOOL)validateIdUserFriend:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPagedFriendTimelineModel *pagedFriendTimeline;

//- (BOOL)validatePagedFriendTimeline:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *timeLine;

- (NSMutableSet*)timeLineSet;

@end

@interface _MDPFriendTimelineModel (TimeLineCoreDataGeneratedAccessors)
- (void)addTimeLine:(NSSet*)value_;
- (void)removeTimeLine:(NSSet*)value_;
- (void)addTimeLineObject:(MDPUserActionHistoryModel*)value_;
- (void)removeTimeLineObject:(MDPUserActionHistoryModel*)value_;
@end

@interface _MDPFriendTimelineModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAlias;
- (void)setPrimitiveAlias:(NSString*)value;

- (NSString*)primitiveAvatarThumbnailUrl;
- (void)setPrimitiveAvatarThumbnailUrl:(NSString*)value;

- (NSString*)primitiveAvatarUrl;
- (void)setPrimitiveAvatarUrl:(NSString*)value;

- (NSString*)primitiveIdUserFriend;
- (void)setPrimitiveIdUserFriend:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (MDPPagedFriendTimelineModel*)primitivePagedFriendTimeline;
- (void)setPrimitivePagedFriendTimeline:(MDPPagedFriendTimelineModel*)value;

- (NSMutableSet*)primitiveTimeLine;
- (void)setPrimitiveTimeLine:(NSMutableSet*)value;

@end
