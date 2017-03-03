//
//  _MDPOpenThreadModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPOpenThreadModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPOpenThreadModelAttributes {
	__unsafe_unretained NSString *friendAlias;
	__unsafe_unretained NSString *friendAvatarThumbnailUrl;
	__unsafe_unretained NSString *friendAvatarUrl;
	__unsafe_unretained NSString *idThread;
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *idUserFriend;
	__unsafe_unretained NSString *lastMessageDate;
	__unsafe_unretained NSString *lastMessageText;
	__unsafe_unretained NSString *lastUpdateAt;
} MDPOpenThreadModelAttributes;

extern const struct MDPOpenThreadModelRelationships {
	__unsafe_unretained NSString *pagedOpenThreads;
} MDPOpenThreadModelRelationships;

@class MDPPagedOpenThreadsModel;

@interface _MDPOpenThreadModel : NSManagedObject

@property (nonatomic, strong) NSString* friendAlias;

//- (BOOL)validateFriendAlias:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* friendAvatarThumbnailUrl;

//- (BOOL)validateFriendAvatarThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* friendAvatarUrl;

//- (BOOL)validateFriendAvatarUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idThread;

//- (BOOL)validateIdThread:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUserFriend;

//- (BOOL)validateIdUserFriend:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastMessageDate;

//- (BOOL)validateLastMessageDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* lastMessageText;

//- (BOOL)validateLastMessageText:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPagedOpenThreadsModel *pagedOpenThreads;

//- (BOOL)validatePagedOpenThreads:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPOpenThreadModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveFriendAlias;
- (void)setPrimitiveFriendAlias:(NSString*)value;

- (NSString*)primitiveFriendAvatarThumbnailUrl;
- (void)setPrimitiveFriendAvatarThumbnailUrl:(NSString*)value;

- (NSString*)primitiveFriendAvatarUrl;
- (void)setPrimitiveFriendAvatarUrl:(NSString*)value;

- (NSString*)primitiveIdThread;
- (void)setPrimitiveIdThread:(NSString*)value;

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSString*)primitiveIdUserFriend;
- (void)setPrimitiveIdUserFriend:(NSString*)value;

- (NSDate*)primitiveLastMessageDate;
- (void)setPrimitiveLastMessageDate:(NSDate*)value;

- (NSString*)primitiveLastMessageText;
- (void)setPrimitiveLastMessageText:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (MDPPagedOpenThreadsModel*)primitivePagedOpenThreads;
- (void)setPrimitivePagedOpenThreads:(MDPPagedOpenThreadsModel*)value;

@end
