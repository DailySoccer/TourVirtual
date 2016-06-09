//
//  _MDPBasketLiveMatchModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPBasketLiveMatchModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPBasketLiveMatchModelAttributes {
	__unsafe_unretained NSString *attendance;
	__unsafe_unretained NSString *competitionName;
	__unsafe_unretained NSString *date;
	__unsafe_unretained NSString *idCompetition;
	__unsafe_unretained NSString *idMatch;
	__unsafe_unretained NSString *idSeason;
	__unsafe_unretained NSString *idStadium;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *occupancyRate;
	__unsafe_unretained NSString *seasonName;
	__unsafe_unretained NSString *stadiumName;
} MDPBasketLiveMatchModelAttributes;

extern const struct MDPBasketLiveMatchModelRelationships {
	__unsafe_unretained NSString *awayTeam;
	__unsafe_unretained NSString *boxscoreEvolution;
	__unsafe_unretained NSString *boxscoreEvolutionResume;
	__unsafe_unretained NSString *boxscorePerQuarter;
	__unsafe_unretained NSString *homeTeam;
	__unsafe_unretained NSString *matchOfficials;
} MDPBasketLiveMatchModelRelationships;

@class MDPBasketTeamDataModel;
@class MDPBasketBoxscoreModel;
@class MDPBasketBoxscoreModel;
@class MDPBasketBoxscoreModel;
@class MDPBasketTeamDataModel;
@class MDPMatchOfficialModel;

@interface _MDPBasketLiveMatchModel : NSManagedObject

@property (nonatomic, strong) NSString* attendance;

//- (BOOL)validateAttendance:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* competitionName;

//- (BOOL)validateCompetitionName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* date;

//- (BOOL)validateDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idCompetition;

//- (BOOL)validateIdCompetition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idMatch;

//- (BOOL)validateIdMatch:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSeason;

//- (BOOL)validateIdSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* idStadium;

@property (atomic) int64_t idStadiumValue;
- (int64_t)idStadiumValue;
- (void)setIdStadiumValue:(int64_t)value_;

//- (BOOL)validateIdStadium:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* occupancyRate;

@property (atomic) int64_t occupancyRateValue;
- (int64_t)occupancyRateValue;
- (void)setOccupancyRateValue:(int64_t)value_;

//- (BOOL)validateOccupancyRate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* seasonName;

//- (BOOL)validateSeasonName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* stadiumName;

//- (BOOL)validateStadiumName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPBasketTeamDataModel *awayTeam;

//- (BOOL)validateAwayTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *boxscoreEvolution;

- (NSMutableSet*)boxscoreEvolutionSet;

@property (nonatomic, strong) NSSet *boxscoreEvolutionResume;

- (NSMutableSet*)boxscoreEvolutionResumeSet;

@property (nonatomic, strong) NSSet *boxscorePerQuarter;

- (NSMutableSet*)boxscorePerQuarterSet;

@property (nonatomic, strong) MDPBasketTeamDataModel *homeTeam;

//- (BOOL)validateHomeTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *matchOfficials;

- (NSMutableSet*)matchOfficialsSet;

@end

@interface _MDPBasketLiveMatchModel (BoxscoreEvolutionCoreDataGeneratedAccessors)
- (void)addBoxscoreEvolution:(NSSet*)value_;
- (void)removeBoxscoreEvolution:(NSSet*)value_;
- (void)addBoxscoreEvolutionObject:(MDPBasketBoxscoreModel*)value_;
- (void)removeBoxscoreEvolutionObject:(MDPBasketBoxscoreModel*)value_;
@end

@interface _MDPBasketLiveMatchModel (BoxscoreEvolutionResumeCoreDataGeneratedAccessors)
- (void)addBoxscoreEvolutionResume:(NSSet*)value_;
- (void)removeBoxscoreEvolutionResume:(NSSet*)value_;
- (void)addBoxscoreEvolutionResumeObject:(MDPBasketBoxscoreModel*)value_;
- (void)removeBoxscoreEvolutionResumeObject:(MDPBasketBoxscoreModel*)value_;
@end

@interface _MDPBasketLiveMatchModel (BoxscorePerQuarterCoreDataGeneratedAccessors)
- (void)addBoxscorePerQuarter:(NSSet*)value_;
- (void)removeBoxscorePerQuarter:(NSSet*)value_;
- (void)addBoxscorePerQuarterObject:(MDPBasketBoxscoreModel*)value_;
- (void)removeBoxscorePerQuarterObject:(MDPBasketBoxscoreModel*)value_;
@end

@interface _MDPBasketLiveMatchModel (MatchOfficialsCoreDataGeneratedAccessors)
- (void)addMatchOfficials:(NSSet*)value_;
- (void)removeMatchOfficials:(NSSet*)value_;
- (void)addMatchOfficialsObject:(MDPMatchOfficialModel*)value_;
- (void)removeMatchOfficialsObject:(MDPMatchOfficialModel*)value_;
@end

@interface _MDPBasketLiveMatchModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAttendance;
- (void)setPrimitiveAttendance:(NSString*)value;

- (NSString*)primitiveCompetitionName;
- (void)setPrimitiveCompetitionName:(NSString*)value;

- (NSDate*)primitiveDate;
- (void)setPrimitiveDate:(NSDate*)value;

- (NSString*)primitiveIdCompetition;
- (void)setPrimitiveIdCompetition:(NSString*)value;

- (NSString*)primitiveIdMatch;
- (void)setPrimitiveIdMatch:(NSString*)value;

- (NSString*)primitiveIdSeason;
- (void)setPrimitiveIdSeason:(NSString*)value;

- (NSNumber*)primitiveIdStadium;
- (void)setPrimitiveIdStadium:(NSNumber*)value;

- (int64_t)primitiveIdStadiumValue;
- (void)setPrimitiveIdStadiumValue:(int64_t)value_;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveOccupancyRate;
- (void)setPrimitiveOccupancyRate:(NSNumber*)value;

- (int64_t)primitiveOccupancyRateValue;
- (void)setPrimitiveOccupancyRateValue:(int64_t)value_;

- (NSString*)primitiveSeasonName;
- (void)setPrimitiveSeasonName:(NSString*)value;

- (NSString*)primitiveStadiumName;
- (void)setPrimitiveStadiumName:(NSString*)value;

- (MDPBasketTeamDataModel*)primitiveAwayTeam;
- (void)setPrimitiveAwayTeam:(MDPBasketTeamDataModel*)value;

- (NSMutableSet*)primitiveBoxscoreEvolution;
- (void)setPrimitiveBoxscoreEvolution:(NSMutableSet*)value;

- (NSMutableSet*)primitiveBoxscoreEvolutionResume;
- (void)setPrimitiveBoxscoreEvolutionResume:(NSMutableSet*)value;

- (NSMutableSet*)primitiveBoxscorePerQuarter;
- (void)setPrimitiveBoxscorePerQuarter:(NSMutableSet*)value;

- (MDPBasketTeamDataModel*)primitiveHomeTeam;
- (void)setPrimitiveHomeTeam:(MDPBasketTeamDataModel*)value;

- (NSMutableSet*)primitiveMatchOfficials;
- (void)setPrimitiveMatchOfficials:(NSMutableSet*)value;

@end
