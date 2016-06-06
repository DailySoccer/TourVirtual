//
//  _MDPIndexedFanModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPIndexedFanModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPIndexedFanModelAttributes {
	__unsafe_unretained NSString *alias;
	__unsafe_unretained NSString *birthDate;
	__unsafe_unretained NSString *email;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *pictureUrl;
	__unsafe_unretained NSString *thumbnailUrl;
	__unsafe_unretained NSString *userId;
} MDPIndexedFanModelAttributes;

extern const struct MDPIndexedFanModelRelationships {
	__unsafe_unretained NSString *invitationModelHostUser;
} MDPIndexedFanModelRelationships;

@class MDPInvitationModel;

@interface _MDPIndexedFanModel : NSManagedObject

@property (nonatomic, strong) NSString* alias;

//- (BOOL)validateAlias:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* birthDate;

//- (BOOL)validateBirthDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* email;

//- (BOOL)validateEmail:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* pictureUrl;

//- (BOOL)validatePictureUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* thumbnailUrl;

//- (BOOL)validateThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* userId;

//- (BOOL)validateUserId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *invitationModelHostUser;

- (NSMutableSet*)invitationModelHostUserSet;

@end

@interface _MDPIndexedFanModel (InvitationModelHostUserCoreDataGeneratedAccessors)
- (void)addInvitationModelHostUser:(NSSet*)value_;
- (void)removeInvitationModelHostUser:(NSSet*)value_;
- (void)addInvitationModelHostUserObject:(MDPInvitationModel*)value_;
- (void)removeInvitationModelHostUserObject:(MDPInvitationModel*)value_;
@end

@interface _MDPIndexedFanModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAlias;
- (void)setPrimitiveAlias:(NSString*)value;

- (NSDate*)primitiveBirthDate;
- (void)setPrimitiveBirthDate:(NSDate*)value;

- (NSString*)primitiveEmail;
- (void)setPrimitiveEmail:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSString*)primitivePictureUrl;
- (void)setPrimitivePictureUrl:(NSString*)value;

- (NSString*)primitiveThumbnailUrl;
- (void)setPrimitiveThumbnailUrl:(NSString*)value;

- (NSString*)primitiveUserId;
- (void)setPrimitiveUserId:(NSString*)value;

- (NSMutableSet*)primitiveInvitationModelHostUser;
- (void)setPrimitiveInvitationModelHostUser:(NSMutableSet*)value;

@end
