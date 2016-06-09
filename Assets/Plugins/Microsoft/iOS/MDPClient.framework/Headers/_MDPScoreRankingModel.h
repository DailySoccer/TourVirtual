//
//  _MDPScoreRankingModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPScoreRankingModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPScoreRankingModelAttributes {
	__unsafe_unretained NSString *alias;
	__unsafe_unretained NSString *avatarUrl;
	__unsafe_unretained NSString *idGame;
	__unsafe_unretained NSString *isCurrentUser;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *position;
	__unsafe_unretained NSString *score;
} MDPScoreRankingModelAttributes;

@interface _MDPScoreRankingModel : NSManagedObject

@property (nonatomic, strong) NSString* alias;

//- (BOOL)validateAlias:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* avatarUrl;

//- (BOOL)validateAvatarUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idGame;

//- (BOOL)validateIdGame:(id*)value_ error:(NSError**)error_;

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

@property (nonatomic, strong) NSNumber* score;

@property (atomic) int64_t scoreValue;
- (int64_t)scoreValue;
- (void)setScoreValue:(int64_t)value_;

//- (BOOL)validateScore:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPScoreRankingModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAlias;
- (void)setPrimitiveAlias:(NSString*)value;

- (NSString*)primitiveAvatarUrl;
- (void)setPrimitiveAvatarUrl:(NSString*)value;

- (NSString*)primitiveIdGame;
- (void)setPrimitiveIdGame:(NSString*)value;

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

- (NSNumber*)primitiveScore;
- (void)setPrimitiveScore:(NSNumber*)value;

- (int64_t)primitiveScoreValue;
- (void)setPrimitiveScoreValue:(int64_t)value_;

@end
