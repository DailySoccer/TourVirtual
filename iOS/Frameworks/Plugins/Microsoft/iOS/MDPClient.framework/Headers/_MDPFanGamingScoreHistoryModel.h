//
//  _MDPFanGamingScoreHistoryModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPFanGamingScoreHistoryModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPFanGamingScoreHistoryModelAttributes {
	__unsafe_unretained NSString *actionDate;
	__unsafe_unretained NSString *idAchievement;
	__unsafe_unretained NSString *idAction;
	__unsafe_unretained NSString *idClientGroup;
	__unsafe_unretained NSString *idTimestamp;
	__unsafe_unretained NSString *idUser;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *level;
	__unsafe_unretained NSString *name;
	__unsafe_unretained NSString *score;
} MDPFanGamingScoreHistoryModelAttributes;

extern const struct MDPFanGamingScoreHistoryModelRelationships {
	__unsafe_unretained NSString *pagedFanGamingScoreHistoryResults;
} MDPFanGamingScoreHistoryModelRelationships;

@class MDPPagedFanGamingScoreHistoryModel;

@interface _MDPFanGamingScoreHistoryModel : NSManagedObject

@property (nonatomic, strong) NSDate* actionDate;

//- (BOOL)validateActionDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idAchievement;

//- (BOOL)validateIdAchievement:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idAction;

//- (BOOL)validateIdAction:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idClientGroup;

//- (BOOL)validateIdClientGroup:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idTimestamp;

//- (BOOL)validateIdTimestamp:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idUser;

//- (BOOL)validateIdUser:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* level;

@property (atomic) int64_t levelValue;
- (int64_t)levelValue;
- (void)setLevelValue:(int64_t)value_;

//- (BOOL)validateLevel:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* name;

//- (BOOL)validateName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* score;

@property (atomic) int64_t scoreValue;
- (int64_t)scoreValue;
- (void)setScoreValue:(int64_t)value_;

//- (BOOL)validateScore:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *pagedFanGamingScoreHistoryResults;

- (NSMutableSet*)pagedFanGamingScoreHistoryResultsSet;

@end

@interface _MDPFanGamingScoreHistoryModel (PagedFanGamingScoreHistoryResultsCoreDataGeneratedAccessors)
- (void)addPagedFanGamingScoreHistoryResults:(NSSet*)value_;
- (void)removePagedFanGamingScoreHistoryResults:(NSSet*)value_;
- (void)addPagedFanGamingScoreHistoryResultsObject:(MDPPagedFanGamingScoreHistoryModel*)value_;
- (void)removePagedFanGamingScoreHistoryResultsObject:(MDPPagedFanGamingScoreHistoryModel*)value_;
@end

@interface _MDPFanGamingScoreHistoryModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveActionDate;
- (void)setPrimitiveActionDate:(NSDate*)value;

- (NSString*)primitiveIdAchievement;
- (void)setPrimitiveIdAchievement:(NSString*)value;

- (NSString*)primitiveIdAction;
- (void)setPrimitiveIdAction:(NSString*)value;

- (NSString*)primitiveIdClientGroup;
- (void)setPrimitiveIdClientGroup:(NSString*)value;

- (NSString*)primitiveIdTimestamp;
- (void)setPrimitiveIdTimestamp:(NSString*)value;

- (NSString*)primitiveIdUser;
- (void)setPrimitiveIdUser:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveLevel;
- (void)setPrimitiveLevel:(NSNumber*)value;

- (int64_t)primitiveLevelValue;
- (void)setPrimitiveLevelValue:(int64_t)value_;

- (NSString*)primitiveName;
- (void)setPrimitiveName:(NSString*)value;

- (NSNumber*)primitiveScore;
- (void)setPrimitiveScore:(NSNumber*)value;

- (int64_t)primitiveScoreValue;
- (void)setPrimitiveScoreValue:(int64_t)value_;

- (NSMutableSet*)primitivePagedFanGamingScoreHistoryResults;
- (void)setPrimitivePagedFanGamingScoreHistoryResults:(NSMutableSet*)value;

@end
