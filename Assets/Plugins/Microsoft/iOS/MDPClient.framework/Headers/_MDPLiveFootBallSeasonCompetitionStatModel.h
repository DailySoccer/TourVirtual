//
//  _MDPLiveFootBallSeasonCompetitionStatModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPLiveFootBallSeasonCompetitionStatModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPLiveFootBallSeasonCompetitionStatModelAttributes {
	__unsafe_unretained NSString *idCompetition;
	__unsafe_unretained NSString *idSeason;
	__unsafe_unretained NSString *idTeam;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *teamName;
} MDPLiveFootBallSeasonCompetitionStatModelAttributes;

extern const struct MDPLiveFootBallSeasonCompetitionStatModelRelationships {
	__unsafe_unretained NSString *statistics;
} MDPLiveFootBallSeasonCompetitionStatModelRelationships;

@class MDPStatisticTypeModel;

@interface _MDPLiveFootBallSeasonCompetitionStatModel : NSManagedObject

@property (nonatomic, strong) NSString* idCompetition;

//- (BOOL)validateIdCompetition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSeason;

//- (BOOL)validateIdSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idTeam;

//- (BOOL)validateIdTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* teamName;

//- (BOOL)validateTeamName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *statistics;

- (NSMutableSet*)statisticsSet;

@end

@interface _MDPLiveFootBallSeasonCompetitionStatModel (StatisticsCoreDataGeneratedAccessors)
- (void)addStatistics:(NSSet*)value_;
- (void)removeStatistics:(NSSet*)value_;
- (void)addStatisticsObject:(MDPStatisticTypeModel*)value_;
- (void)removeStatisticsObject:(MDPStatisticTypeModel*)value_;
@end

@interface _MDPLiveFootBallSeasonCompetitionStatModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdCompetition;
- (void)setPrimitiveIdCompetition:(NSString*)value;

- (NSString*)primitiveIdSeason;
- (void)setPrimitiveIdSeason:(NSString*)value;

- (NSString*)primitiveIdTeam;
- (void)setPrimitiveIdTeam:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveTeamName;
- (void)setPrimitiveTeamName:(NSString*)value;

- (NSMutableSet*)primitiveStatistics;
- (void)setPrimitiveStatistics:(NSMutableSet*)value;

@end
