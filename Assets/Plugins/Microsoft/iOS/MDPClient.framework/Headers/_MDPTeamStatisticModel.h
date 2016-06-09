//
//  _MDPTeamStatisticModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPTeamStatisticModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPTeamStatisticModelAttributes {
	__unsafe_unretained NSString *competitionName;
	__unsafe_unretained NSString *idCompetition;
	__unsafe_unretained NSString *idSeason;
	__unsafe_unretained NSString *idTeam;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *seasonName;
	__unsafe_unretained NSString *sportType;
	__unsafe_unretained NSString *teamName;
} MDPTeamStatisticModelAttributes;

extern const struct MDPTeamStatisticModelRelationships {
	__unsafe_unretained NSString *statistics;
} MDPTeamStatisticModelRelationships;

@class MDPStatisticTypeModel;

@interface _MDPTeamStatisticModel : NSManagedObject

@property (nonatomic, strong) NSString* competitionName;

//- (BOOL)validateCompetitionName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idCompetition;

//- (BOOL)validateIdCompetition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSeason;

//- (BOOL)validateIdSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idTeam;

//- (BOOL)validateIdTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* seasonName;

//- (BOOL)validateSeasonName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* sportType;

@property (atomic) uint16_t sportTypeValue;
- (uint16_t)sportTypeValue;
- (void)setSportTypeValue:(uint16_t)value_;

//- (BOOL)validateSportType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* teamName;

//- (BOOL)validateTeamName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *statistics;

- (NSMutableSet*)statisticsSet;

@end

@interface _MDPTeamStatisticModel (StatisticsCoreDataGeneratedAccessors)
- (void)addStatistics:(NSSet*)value_;
- (void)removeStatistics:(NSSet*)value_;
- (void)addStatisticsObject:(MDPStatisticTypeModel*)value_;
- (void)removeStatisticsObject:(MDPStatisticTypeModel*)value_;
@end

@interface _MDPTeamStatisticModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveCompetitionName;
- (void)setPrimitiveCompetitionName:(NSString*)value;

- (NSString*)primitiveIdCompetition;
- (void)setPrimitiveIdCompetition:(NSString*)value;

- (NSString*)primitiveIdSeason;
- (void)setPrimitiveIdSeason:(NSString*)value;

- (NSString*)primitiveIdTeam;
- (void)setPrimitiveIdTeam:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveSeasonName;
- (void)setPrimitiveSeasonName:(NSString*)value;

- (NSNumber*)primitiveSportType;
- (void)setPrimitiveSportType:(NSNumber*)value;

- (uint16_t)primitiveSportTypeValue;
- (void)setPrimitiveSportTypeValue:(uint16_t)value_;

- (NSString*)primitiveTeamName;
- (void)setPrimitiveTeamName:(NSString*)value;

- (NSMutableSet*)primitiveStatistics;
- (void)setPrimitiveStatistics:(NSMutableSet*)value;

@end
