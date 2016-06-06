//
//  _MDPFriendModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPFriendModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPFriendModelAttributes {
	__unsafe_unretained NSString *alias;
	__unsafe_unretained NSString *avatarThumbnailUrl;
	__unsafe_unretained NSString *avatarUrl;
	__unsafe_unretained NSString *friendShipDate;
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *idUserFriend;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *messagesThreadId;
	__unsafe_unretained NSString *name;
} MDPFriendModelAttributes;

@interface _MDPFriendModel : NSManagedObject

@property (nonatomic, strong) NSString* alias;

//- (BOOL)validateAlias:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* avatarThumbnailUrl;

//- (BOOL)validateAvatarThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* avatarUrl;

//- (BOOL)validateAvatarUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* friendShipDate;

//- (BOOL)validateFriendShipDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUserFriend;

//- (BOOL)validateIdUserFriend:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* messagesThreadId;

//- (BOOL)validateMessagesThreadId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPFriendModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAlias;
- (void)setPrimitiveAlias:(NSString*)value;

- (NSString*)primitiveAvatarThumbnailUrl;
- (void)setPrimitiveAvatarThumbnailUrl:(NSString*)value;

- (NSString*)primitiveAvatarUrl;
- (void)setPrimitiveAvatarUrl:(NSString*)value;

- (NSDate*)primitiveFriendShipDate;
- (void)setPrimitiveFriendShipDate:(NSDate*)value;

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSString*)primitiveIdUserFriend;
- (void)setPrimitiveIdUserFriend:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveMessagesThreadId;
- (void)setPrimitiveMessagesThreadId:(NSString*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

@end
