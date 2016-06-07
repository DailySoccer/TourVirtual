//
//  _MDPFanContactModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPFanContactModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPFanContactModelAttributes {
	__unsafe_unretained NSString *alias;
	__unsafe_unretained NSString *avatarName;
	__unsafe_unretained NSString *avatarThumbnailName;
	__unsafe_unretained NSString *country;
	__unsafe_unretained NSString *gamingScore;
	__unsafe_unretained NSString *hasAvatar;
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *isFriend;
	__unsafe_unretained NSString *isInvitationSent;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *registrationDate;
} MDPFanContactModelAttributes;

extern const struct MDPFanContactModelRelationships {
	__unsafe_unretained NSString *contactExtended;
} MDPFanContactModelRelationships;

@class MDPFanContactExtendedModel;

@interface _MDPFanContactModel : NSManagedObject

@property (nonatomic, strong) NSString* alias;

//- (BOOL)validateAlias:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* avatarName;

//- (BOOL)validateAvatarName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* avatarThumbnailName;

//- (BOOL)validateAvatarThumbnailName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* country;

//- (BOOL)validateCountry:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* gamingScore;

@property (atomic) int64_t gamingScoreValue;
- (int64_t)gamingScoreValue;
- (void)setGamingScoreValue:(int64_t)value_;

//- (BOOL)validateGamingScore:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* hasAvatar;

@property (atomic) BOOL hasAvatarValue;
- (BOOL)hasAvatarValue;
- (void)setHasAvatarValue:(BOOL)value_;

//- (BOOL)validateHasAvatar:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* isFriend;

@property (atomic) BOOL isFriendValue;
- (BOOL)isFriendValue;
- (void)setIsFriendValue:(BOOL)value_;

//- (BOOL)validateIsFriend:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* isInvitationSent;

@property (atomic) BOOL isInvitationSentValue;
- (BOOL)isInvitationSentValue;
- (void)setIsInvitationSentValue:(BOOL)value_;

//- (BOOL)validateIsInvitationSent:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* registrationDate;

//- (BOOL)validateRegistrationDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFanContactExtendedModel *contactExtended;

//- (BOOL)validateContactExtended:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPFanContactModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAlias;
- (void)setPrimitiveAlias:(NSString*)value;

- (NSString*)primitiveAvatarName;
- (void)setPrimitiveAvatarName:(NSString*)value;

- (NSString*)primitiveAvatarThumbnailName;
- (void)setPrimitiveAvatarThumbnailName:(NSString*)value;

- (NSString*)primitiveCountry;
- (void)setPrimitiveCountry:(NSString*)value;

- (NSNumber*)primitiveGamingScore;
- (void)setPrimitiveGamingScore:(NSNumber*)value;

- (int64_t)primitiveGamingScoreValue;
- (void)setPrimitiveGamingScoreValue:(int64_t)value_;

- (NSNumber*)primitiveHasAvatar;
- (void)setPrimitiveHasAvatar:(NSNumber*)value;

- (BOOL)primitiveHasAvatarValue;
- (void)setPrimitiveHasAvatarValue:(BOOL)value_;

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSNumber*)primitiveIsFriend;
- (void)setPrimitiveIsFriend:(NSNumber*)value;

- (BOOL)primitiveIsFriendValue;
- (void)setPrimitiveIsFriendValue:(BOOL)value_;

- (NSNumber*)primitiveIsInvitationSent;
- (void)setPrimitiveIsInvitationSent:(NSNumber*)value;

- (BOOL)primitiveIsInvitationSentValue;
- (void)setPrimitiveIsInvitationSentValue:(BOOL)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSDate*)primitiveRegistrationDate;
- (void)setPrimitiveRegistrationDate:(NSDate*)value;

- (MDPFanContactExtendedModel*)primitiveContactExtended;
- (void)setPrimitiveContactExtended:(MDPFanContactExtendedModel*)value;

@end
