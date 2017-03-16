//
//  _MDPFootballTeamDataModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPFootballTeamDataModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPFootballTeamDataModelAttributes {
	__unsafe_unretained NSString *idTeam;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *score;
	__unsafe_unretained NSString *shootOutScore;
	__unsafe_unretained NSString *side;
	__unsafe_unretained NSString *teamName;
} MDPFootballTeamDataModelAttributes;

extern const struct MDPFootballTeamDataModelRelationships {
	__unsafe_unretained NSString *ballPossession;
	__unsafe_unretained NSString *bookings;
	__unsafe_unretained NSString *footballLiveMatchAwayTeam;
	__unsafe_unretained NSString *footballLiveMatchHomeTeam;
	__unsafe_unretained NSString *goals;
	__unsafe_unretained NSString *playerLineUp;
	__unsafe_unretained NSString *shootOut;
	__unsafe_unretained NSString *substitutions;
	__unsafe_unretained NSString *territorialPossesion;
	__unsafe_unretained NSString *territorialThirdPossesion;
} MDPFootballTeamDataModelRelationships;

@class MDPPossessionModel;
@class MDPBookingModel;
@class MDPFootballLiveMatchModel;
@class MDPFootballLiveMatchModel;
@class MDPGoalModel;
@class MDPFootballMatchPlayerModel;
@class MDPShootOutModel;
@class MDPSubstitutionModel;
@class MDPPossessionModel;
@class MDPPossessionModel;

@interface _MDPFootballTeamDataModel : NSManagedObject

@property (nonatomic, strong) NSString* idTeam;

//- (BOOL)validateIdTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* score;

@property (atomic) int64_t scoreValue;
- (int64_t)scoreValue;
- (void)setScoreValue:(int64_t)value_;

//- (BOOL)validateScore:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* shootOutScore;

@property (atomic) int64_t shootOutScoreValue;
- (int64_t)shootOutScoreValue;
- (void)setShootOutScoreValue:(int64_t)value_;

//- (BOOL)validateShootOutScore:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* side;

//- (BOOL)validateSide:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* teamName;

//- (BOOL)validateTeamName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPossessionModel *ballPossession;

//- (BOOL)validateBallPossession:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *bookings;

- (NSMutableSet*)bookingsSet;

@property (nonatomic, strong) MDPFootballLiveMatchModel *footballLiveMatchAwayTeam;

//- (BOOL)validateFootballLiveMatchAwayTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFootballLiveMatchModel *footballLiveMatchHomeTeam;

//- (BOOL)validateFootballLiveMatchHomeTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *goals;

- (NSMutableSet*)goalsSet;

@property (nonatomic, strong) NSOrderedSet *playerLineUp;

- (NSMutableOrderedSet*)playerLineUpSet;

@property (nonatomic, strong) MDPShootOutModel *shootOut;

//- (BOOL)validateShootOut:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *substitutions;

- (NSMutableSet*)substitutionsSet;

@property (nonatomic, strong) MDPPossessionModel *territorialPossesion;

//- (BOOL)validateTerritorialPossesion:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPossessionModel *territorialThirdPossesion;

//- (BOOL)validateTerritorialThirdPossesion:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPFootballTeamDataModel (BookingsCoreDataGeneratedAccessors)
- (void)addBookings:(NSSet*)value_;
- (void)removeBookings:(NSSet*)value_;
- (void)addBookingsObject:(MDPBookingModel*)value_;
- (void)removeBookingsObject:(MDPBookingModel*)value_;
@end

@interface _MDPFootballTeamDataModel (GoalsCoreDataGeneratedAccessors)
- (void)addGoals:(NSSet*)value_;
- (void)removeGoals:(NSSet*)value_;
- (void)addGoalsObject:(MDPGoalModel*)value_;
- (void)removeGoalsObject:(MDPGoalModel*)value_;
@end

@interface _MDPFootballTeamDataModel (PlayerLineUpCoreDataGeneratedAccessors)
- (void)addPlayerLineUp:(NSOrderedSet*)value_;
- (void)removePlayerLineUp:(NSOrderedSet*)value_;
- (void)addPlayerLineUpObject:(MDPFootballMatchPlayerModel*)value_;
- (void)removePlayerLineUpObject:(MDPFootballMatchPlayerModel*)value_;
@end

@interface _MDPFootballTeamDataModel (SubstitutionsCoreDataGeneratedAccessors)
- (void)addSubstitutions:(NSSet*)value_;
- (void)removeSubstitutions:(NSSet*)value_;
- (void)addSubstitutionsObject:(MDPSubstitutionModel*)value_;
- (void)removeSubstitutionsObject:(MDPSubstitutionModel*)value_;
@end

@interface _MDPFootballTeamDataModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdTeam;
- (void)setPrimitiveIdTeam:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveScore;
- (void)setPrimitiveScore:(NSNumber*)value;

- (int64_t)primitiveScoreValue;
- (void)setPrimitiveScoreValue:(int64_t)value_;

- (NSNumber*)primitiveShootOutScore;
- (void)setPrimitiveShootOutScore:(NSNumber*)value;

- (int64_t)primitiveShootOutScoreValue;
- (void)setPrimitiveShootOutScoreValue:(int64_t)value_;

- (NSString*)primitiveSide;
- (void)setPrimitiveSide:(NSString*)value;

- (NSString*)primitiveTeamName;
- (void)setPrimitiveTeamName:(NSString*)value;

- (MDPPossessionModel*)primitiveBallPossession;
- (void)setPrimitiveBallPossession:(MDPPossessionModel*)value;

- (NSMutableSet*)primitiveBookings;
- (void)setPrimitiveBookings:(NSMutableSet*)value;

- (MDPFootballLiveMatchModel*)primitiveFootballLiveMatchAwayTeam;
- (void)setPrimitiveFootballLiveMatchAwayTeam:(MDPFootballLiveMatchModel*)value;

- (MDPFootballLiveMatchModel*)primitiveFootballLiveMatchHomeTeam;
- (void)setPrimitiveFootballLiveMatchHomeTeam:(MDPFootballLiveMatchModel*)value;

- (NSMutableSet*)primitiveGoals;
- (void)setPrimitiveGoals:(NSMutableSet*)value;

- (NSMutableOrderedSet*)primitivePlayerLineUp;
- (void)setPrimitivePlayerLineUp:(NSMutableOrderedSet*)value;

- (MDPShootOutModel*)primitiveShootOut;
- (void)setPrimitiveShootOut:(MDPShootOutModel*)value;

- (NSMutableSet*)primitiveSubstitutions;
- (void)setPrimitiveSubstitutions:(NSMutableSet*)value;

- (MDPPossessionModel*)primitiveTerritorialPossesion;
- (void)setPrimitiveTerritorialPossesion:(MDPPossessionModel*)value;

- (MDPPossessionModel*)primitiveTerritorialThirdPossesion;
- (void)setPrimitiveTerritorialThirdPossesion:(MDPPossessionModel*)value;

@end
