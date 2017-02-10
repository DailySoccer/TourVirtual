//
//  _MDPPossessionModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPPossessionModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPPossessionModelAttributes {
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *overallAway;
	__unsafe_unretained NSString *overallHome;
} MDPPossessionModelAttributes;

extern const struct MDPPossessionModelRelationships {
	__unsafe_unretained NSString *footballLiveMatchBallPossession;
	__unsafe_unretained NSString *footballLiveMatchBallTerritorialPossesion;
	__unsafe_unretained NSString *footballLiveMatchTerritorialThirdPossesion;
	__unsafe_unretained NSString *footballTeamDataBallPossession;
	__unsafe_unretained NSString *footballTeamDataTerritorialPossesion;
	__unsafe_unretained NSString *footballTeamDataTerritorialThirdPossesion;
	__unsafe_unretained NSString *intervals;
	__unsafe_unretained NSString *lastX;
} MDPPossessionModelRelationships;

@class MDPFootballLiveMatchModel;
@class MDPFootballLiveMatchModel;
@class MDPFootballLiveMatchModel;
@class MDPFootballTeamDataModel;
@class MDPFootballTeamDataModel;
@class MDPFootballTeamDataModel;
@class MDPPossessionIntervalModel;
@class MDPPossessionLastXModel;

@interface _MDPPossessionModel : NSManagedObject

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* overallAway;

//- (BOOL)validateOverallAway:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* overallHome;

//- (BOOL)validateOverallHome:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFootballLiveMatchModel *footballLiveMatchBallPossession;

//- (BOOL)validateFootballLiveMatchBallPossession:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFootballLiveMatchModel *footballLiveMatchBallTerritorialPossesion;

//- (BOOL)validateFootballLiveMatchBallTerritorialPossesion:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFootballLiveMatchModel *footballLiveMatchTerritorialThirdPossesion;

//- (BOOL)validateFootballLiveMatchTerritorialThirdPossesion:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFootballTeamDataModel *footballTeamDataBallPossession;

//- (BOOL)validateFootballTeamDataBallPossession:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFootballTeamDataModel *footballTeamDataTerritorialPossesion;

//- (BOOL)validateFootballTeamDataTerritorialPossesion:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFootballTeamDataModel *footballTeamDataTerritorialThirdPossesion;

//- (BOOL)validateFootballTeamDataTerritorialThirdPossesion:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *intervals;

- (NSMutableSet*)intervalsSet;

@property (nonatomic, strong) NSSet *lastX;

- (NSMutableSet*)lastXSet;

@end

@interface _MDPPossessionModel (IntervalsCoreDataGeneratedAccessors)
- (void)addIntervals:(NSSet*)value_;
- (void)removeIntervals:(NSSet*)value_;
- (void)addIntervalsObject:(MDPPossessionIntervalModel*)value_;
- (void)removeIntervalsObject:(MDPPossessionIntervalModel*)value_;
@end

@interface _MDPPossessionModel (LastXCoreDataGeneratedAccessors)
- (void)addLastX:(NSSet*)value_;
- (void)removeLastX:(NSSet*)value_;
- (void)addLastXObject:(MDPPossessionLastXModel*)value_;
- (void)removeLastXObject:(MDPPossessionLastXModel*)value_;
@end

@interface _MDPPossessionModel (CoreDataGeneratedPrimitiveAccessors)

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveOverallAway;
- (void)setPrimitiveOverallAway:(NSString*)value;

- (NSString*)primitiveOverallHome;
- (void)setPrimitiveOverallHome:(NSString*)value;

- (MDPFootballLiveMatchModel*)primitiveFootballLiveMatchBallPossession;
- (void)setPrimitiveFootballLiveMatchBallPossession:(MDPFootballLiveMatchModel*)value;

- (MDPFootballLiveMatchModel*)primitiveFootballLiveMatchBallTerritorialPossesion;
- (void)setPrimitiveFootballLiveMatchBallTerritorialPossesion:(MDPFootballLiveMatchModel*)value;

- (MDPFootballLiveMatchModel*)primitiveFootballLiveMatchTerritorialThirdPossesion;
- (void)setPrimitiveFootballLiveMatchTerritorialThirdPossesion:(MDPFootballLiveMatchModel*)value;

- (MDPFootballTeamDataModel*)primitiveFootballTeamDataBallPossession;
- (void)setPrimitiveFootballTeamDataBallPossession:(MDPFootballTeamDataModel*)value;

- (MDPFootballTeamDataModel*)primitiveFootballTeamDataTerritorialPossesion;
- (void)setPrimitiveFootballTeamDataTerritorialPossesion:(MDPFootballTeamDataModel*)value;

- (MDPFootballTeamDataModel*)primitiveFootballTeamDataTerritorialThirdPossesion;
- (void)setPrimitiveFootballTeamDataTerritorialThirdPossesion:(MDPFootballTeamDataModel*)value;

- (NSMutableSet*)primitiveIntervals;
- (void)setPrimitiveIntervals:(NSMutableSet*)value;

- (NSMutableSet*)primitiveLastX;
- (void)setPrimitiveLastX:(NSMutableSet*)value;

@end
