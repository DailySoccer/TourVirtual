//
//  _MDPBasketTeamDataModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPBasketTeamDataModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPBasketTeamDataModelAttributes {
	__unsafe_unretained NSString *idTeam;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *manager;
	__unsafe_unretained NSString *points;
	__unsafe_unretained NSString *shortTeamName;
	__unsafe_unretained NSString *teamName;
} MDPBasketTeamDataModelAttributes;

extern const struct MDPBasketTeamDataModelRelationships {
	__unsafe_unretained NSString *basketLiveMatchAwayTeam;
	__unsafe_unretained NSString *basketLiveMatchHomeTeam;
	__unsafe_unretained NSString *lineUp;
} MDPBasketTeamDataModelRelationships;

@class MDPBasketLiveMatchModel;
@class MDPBasketLiveMatchModel;
@class MDPBasketLineUpPlayerModel;

@interface _MDPBasketTeamDataModel : NSManagedObject

@property (nonatomic, strong) NSString* idTeam;

//- (BOOL)validateIdTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* manager;

//- (BOOL)validateManager:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* points;

@property (atomic) int64_t pointsValue;
- (int64_t)pointsValue;
- (void)setPointsValue:(int64_t)value_;

//- (BOOL)validatePoints:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* shortTeamName;

//- (BOOL)validateShortTeamName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* teamName;

//- (BOOL)validateTeamName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPBasketLiveMatchModel *basketLiveMatchAwayTeam;

//- (BOOL)validateBasketLiveMatchAwayTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPBasketLiveMatchModel *basketLiveMatchHomeTeam;

//- (BOOL)validateBasketLiveMatchHomeTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSOrderedSet *lineUp;

- (NSMutableOrderedSet*)lineUpSet;

@end

@interface _MDPBasketTeamDataModel (LineUpCoreDataGeneratedAccessors)
- (void)addLineUp:(NSOrderedSet*)value_;
- (void)removeLineUp:(NSOrderedSet*)value_;
- (void)addLineUpObject:(MDPBasketLineUpPlayerModel*)value_;
- (void)removeLineUpObject:(MDPBasketLineUpPlayerModel*)value_;
@end

@interface _MDPBasketTeamDataModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdTeam;
- (void)setPrimitiveIdTeam:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveManager;
- (void)setPrimitiveManager:(NSString*)value;

- (NSNumber*)primitivePoints;
- (void)setPrimitivePoints:(NSNumber*)value;

- (int64_t)primitivePointsValue;
- (void)setPrimitivePointsValue:(int64_t)value_;

- (NSString*)primitiveShortTeamName;
- (void)setPrimitiveShortTeamName:(NSString*)value;

- (NSString*)primitiveTeamName;
- (void)setPrimitiveTeamName:(NSString*)value;

- (MDPBasketLiveMatchModel*)primitiveBasketLiveMatchAwayTeam;
- (void)setPrimitiveBasketLiveMatchAwayTeam:(MDPBasketLiveMatchModel*)value;

- (MDPBasketLiveMatchModel*)primitiveBasketLiveMatchHomeTeam;
- (void)setPrimitiveBasketLiveMatchHomeTeam:(MDPBasketLiveMatchModel*)value;

- (NSMutableOrderedSet*)primitiveLineUp;
- (void)setPrimitiveLineUp:(NSMutableOrderedSet*)value;

@end
