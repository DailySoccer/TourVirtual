//
//  _MDPExperienceRankingModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPExperienceRankingModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPExperienceRankingModelAttributes {
	__unsafe_unretained NSString *alias;
	__unsafe_unretained NSString *avatarUrl;
	__unsafe_unretained NSString *gamingScore;
	__unsafe_unretained NSString *idClient;
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *isCurrentUser;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *position;
} MDPExperienceRankingModelAttributes;

@interface _MDPExperienceRankingModel : NSManagedObject

@property (nonatomic, strong) NSString* alias;

//- (BOOL)validateAlias:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* avatarUrl;

//- (BOOL)validateAvatarUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* gamingScore;

@property (atomic) int64_t gamingScoreValue;
- (int64_t)gamingScoreValue;
- (void)setGamingScoreValue:(int64_t)value_;

//- (BOOL)validateGamingScore:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idClient;

//- (BOOL)validateIdClient:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* isCurrentUser;

@property (atomic) BOOL isCurrentUserValue;
- (BOOL)isCurrentUserValue;
- (void)setIsCurrentUserValue:(BOOL)value_;

//- (BOOL)validateIsCurrentUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* position;

@property (atomic) int64_t positionValue;
- (int64_t)positionValue;
- (void)setPositionValue:(int64_t)value_;

//- (BOOL)validatePosition:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPExperienceRankingModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAlias;
- (void)setPrimitiveAlias:(NSString*)value;

- (NSString*)primitiveAvatarUrl;
- (void)setPrimitiveAvatarUrl:(NSString*)value;

- (NSNumber*)primitiveGamingScore;
- (void)setPrimitiveGamingScore:(NSNumber*)value;

- (int64_t)primitiveGamingScoreValue;
- (void)setPrimitiveGamingScoreValue:(int64_t)value_;

- (NSString*)primitiveIdClient;
- (void)setPrimitiveIdClient:(NSString*)value;

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSNumber*)primitiveIsCurrentUser;
- (void)setPrimitiveIsCurrentUser:(NSNumber*)value;

- (BOOL)primitiveIsCurrentUserValue;
- (void)setPrimitiveIsCurrentUserValue:(BOOL)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitivePosition;
- (void)setPrimitivePosition:(NSNumber*)value;

- (int64_t)primitivePositionValue;
- (void)setPrimitivePositionValue:(int64_t)value_;

@end
