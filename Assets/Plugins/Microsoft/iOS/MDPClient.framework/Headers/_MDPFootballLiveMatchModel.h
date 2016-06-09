//
//  _MDPFootballLiveMatchModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPFootballLiveMatchModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPFootballLiveMatchModelAttributes {
	__unsafe_unretained NSString *attendance;
	__unsafe_unretained NSString *competitionName;
	__unsafe_unretained NSString *date;
	__unsafe_unretained NSString *firstHalfExtraTime;
	__unsafe_unretained NSString *firstHalfTime;
	__unsafe_unretained NSString *idCompetition;
	__unsafe_unretained NSString *idMatch;
	__unsafe_unretained NSString *idSeason;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *matchTime;
	__unsafe_unretained NSString *seasonName;
	__unsafe_unretained NSString *secondHalfExtraTime;
	__unsafe_unretained NSString *secondHalfTime;
	__unsafe_unretained NSString *weather;
	__unsafe_unretained NSString *winner;
} MDPFootballLiveMatchModelAttributes;

extern const struct MDPFootballLiveMatchModelRelationships {
	__unsafe_unretained NSString *awayTeam;
	__unsafe_unretained NSString *ballPossession;
	__unsafe_unretained NSString *homeTeam;
	__unsafe_unretained NSString *matchOfficials;
	__unsafe_unretained NSString *period;
	__unsafe_unretained NSString *territorialPossesion;
	__unsafe_unretained NSString *territorialThirdPossesion;
} MDPFootballLiveMatchModelRelationships;

@class MDPFootballTeamDataModel;
@class MDPPossessionModel;
@class MDPFootballTeamDataModel;
@class MDPMatchOfficialModel;
@class MDPKeyValueObjectModel;
@class MDPPossessionModel;
@class MDPPossessionModel;

@interface _MDPFootballLiveMatchModel : NSManagedObject

@property (nonatomic, strong) NSString* attendance;

//- (BOOL)validateAttendance:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* competitionName;

//- (BOOL)validateCompetitionName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* date;

//- (BOOL)validateDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* firstHalfExtraTime;

@property (atomic) int64_t firstHalfExtraTimeValue;
- (int64_t)firstHalfExtraTimeValue;
- (void)setFirstHalfExtraTimeValue:(int64_t)value_;

//- (BOOL)validateFirstHalfExtraTime:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* firstHalfTime;

@property (atomic) int64_t firstHalfTimeValue;
- (int64_t)firstHalfTimeValue;
- (void)setFirstHalfTimeValue:(int64_t)value_;

//- (BOOL)validateFirstHalfTime:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idCompetition;

//- (BOOL)validateIdCompetition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idMatch;

//- (BOOL)validateIdMatch:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSeason;

//- (BOOL)validateIdSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* matchTime;

@property (atomic) int64_t matchTimeValue;
- (int64_t)matchTimeValue;
- (void)setMatchTimeValue:(int64_t)value_;

//- (BOOL)validateMatchTime:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* seasonName;

//- (BOOL)validateSeasonName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* secondHalfExtraTime;

@property (atomic) int64_t secondHalfExtraTimeValue;
- (int64_t)secondHalfExtraTimeValue;
- (void)setSecondHalfExtraTimeValue:(int64_t)value_;

//- (BOOL)validateSecondHalfExtraTime:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* secondHalfTime;

@property (atomic) int64_t secondHalfTimeValue;
- (int64_t)secondHalfTimeValue;
- (void)setSecondHalfTimeValue:(int64_t)value_;

//- (BOOL)validateSecondHalfTime:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* weather;

//- (BOOL)validateWeather:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* winner;

//- (BOOL)validateWinner:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFootballTeamDataModel *awayTeam;

//- (BOOL)validateAwayTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPossessionModel *ballPossession;

//- (BOOL)validateBallPossession:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPFootballTeamDataModel *homeTeam;

//- (BOOL)validateHomeTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *matchOfficials;

- (NSMutableSet*)matchOfficialsSet;

@property (nonatomic, strong) MDPKeyValueObjectModel *period;

//- (BOOL)validatePeriod:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPossessionModel *territorialPossesion;

//- (BOOL)validateTerritorialPossesion:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPossessionModel *territorialThirdPossesion;

//- (BOOL)validateTerritorialThirdPossesion:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPFootballLiveMatchModel (MatchOfficialsCoreDataGeneratedAccessors)
- (void)addMatchOfficials:(NSSet*)value_;
- (void)removeMatchOfficials:(NSSet*)value_;
- (void)addMatchOfficialsObject:(MDPMatchOfficialModel*)value_;
- (void)removeMatchOfficialsObject:(MDPMatchOfficialModel*)value_;
@end

@interface _MDPFootballLiveMatchModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAttendance;
- (void)setPrimitiveAttendance:(NSString*)value;

- (NSString*)primitiveCompetitionName;
- (void)setPrimitiveCompetitionName:(NSString*)value;

- (NSDate*)primitiveDate;
- (void)setPrimitiveDate:(NSDate*)value;

- (NSNumber*)primitiveFirstHalfExtraTime;
- (void)setPrimitiveFirstHalfExtraTime:(NSNumber*)value;

- (int64_t)primitiveFirstHalfExtraTimeValue;
- (void)setPrimitiveFirstHalfExtraTimeValue:(int64_t)value_;

- (NSNumber*)primitiveFirstHalfTime;
- (void)setPrimitiveFirstHalfTime:(NSNumber*)value;

- (int64_t)primitiveFirstHalfTimeValue;
- (void)setPrimitiveFirstHalfTimeValue:(int64_t)value_;

- (NSString*)primitiveIdCompetition;
- (void)setPrimitiveIdCompetition:(NSString*)value;

- (NSString*)primitiveIdMatch;
- (void)setPrimitiveIdMatch:(NSString*)value;

- (NSString*)primitiveIdSeason;
- (void)setPrimitiveIdSeason:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveMatchTime;
- (void)setPrimitiveMatchTime:(NSNumber*)value;

- (int64_t)primitiveMatchTimeValue;
- (void)setPrimitiveMatchTimeValue:(int64_t)value_;

- (NSString*)primitiveSeasonName;
- (void)setPrimitiveSeasonName:(NSString*)value;

- (NSNumber*)primitiveSecondHalfExtraTime;
- (void)setPrimitiveSecondHalfExtraTime:(NSNumber*)value;

- (int64_t)primitiveSecondHalfExtraTimeValue;
- (void)setPrimitiveSecondHalfExtraTimeValue:(int64_t)value_;

- (NSNumber*)primitiveSecondHalfTime;
- (void)setPrimitiveSecondHalfTime:(NSNumber*)value;

- (int64_t)primitiveSecondHalfTimeValue;
- (void)setPrimitiveSecondHalfTimeValue:(int64_t)value_;

- (NSString*)primitiveWeather;
- (void)setPrimitiveWeather:(NSString*)value;

- (NSString*)primitiveWinner;
- (void)setPrimitiveWinner:(NSString*)value;

- (MDPFootballTeamDataModel*)primitiveAwayTeam;
- (void)setPrimitiveAwayTeam:(MDPFootballTeamDataModel*)value;

- (MDPPossessionModel*)primitiveBallPossession;
- (void)setPrimitiveBallPossession:(MDPPossessionModel*)value;

- (MDPFootballTeamDataModel*)primitiveHomeTeam;
- (void)setPrimitiveHomeTeam:(MDPFootballTeamDataModel*)value;

- (NSMutableSet*)primitiveMatchOfficials;
- (void)setPrimitiveMatchOfficials:(NSMutableSet*)value;

- (MDPKeyValueObjectModel*)primitivePeriod;
- (void)setPrimitivePeriod:(MDPKeyValueObjectModel*)value;

- (MDPPossessionModel*)primitiveTerritorialPossesion;
- (void)setPrimitiveTerritorialPossesion:(MDPPossessionModel*)value;

- (MDPPossessionModel*)primitiveTerritorialThirdPossesion;
- (void)setPrimitiveTerritorialThirdPossesion:(MDPPossessionModel*)value;

@end
