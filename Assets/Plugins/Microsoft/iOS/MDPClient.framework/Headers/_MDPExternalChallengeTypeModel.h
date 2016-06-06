//
//  _MDPExternalChallengeTypeModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPExternalChallengeTypeModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPExternalChallengeTypeModelAttributes {
	__unsafe_unretained NSString *achievementsClientId;
	__unsafe_unretained NSString *idExternalChallenge;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *order;
} MDPExternalChallengeTypeModelAttributes;

extern const struct MDPExternalChallengeTypeModelRelationships {
	__unsafe_unretained NSString *pageExternalChallengeResults;
} MDPExternalChallengeTypeModelRelationships;

@class MDPPagedExternalChallengeTypeModel;

@interface _MDPExternalChallengeTypeModel : NSManagedObject

@property (nonatomic, strong) NSString* achievementsClientId;

//- (BOOL)validateAchievementsClientId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idExternalChallenge;

//- (BOOL)validateIdExternalChallenge:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* order;

@property (atomic) int64_t orderValue;
- (int64_t)orderValue;
- (void)setOrderValue:(int64_t)value_;

//- (BOOL)validateOrder:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPagedExternalChallengeTypeModel *pageExternalChallengeResults;

//- (BOOL)validatePageExternalChallengeResults:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPExternalChallengeTypeModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAchievementsClientId;
- (void)setPrimitiveAchievementsClientId:(NSString*)value;

- (NSString*)primitiveIdExternalChallenge;
- (void)setPrimitiveIdExternalChallenge:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveOrder;
- (void)setPrimitiveOrder:(NSNumber*)value;

- (int64_t)primitiveOrderValue;
- (void)setPrimitiveOrderValue:(int64_t)value_;

- (MDPPagedExternalChallengeTypeModel*)primitivePageExternalChallengeResults;
- (void)setPrimitivePageExternalChallengeResults:(MDPPagedExternalChallengeTypeModel*)value;

@end
