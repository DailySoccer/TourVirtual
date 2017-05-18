//
//  _MDPFootballLiveMatchTeamStatisticsModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPFootballLiveMatchTeamStatisticsModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPFootballLiveMatchTeamStatisticsModelAttributes {
	__unsafe_unretained NSString *idCompetition;
	__unsafe_unretained NSString *idMatch;
	__unsafe_unretained NSString *idSeason;
	__unsafe_unretained NSString *idTeam;
	__unsafe_unretained NSString *lastUpdateAt;
} MDPFootballLiveMatchTeamStatisticsModelAttributes;

extern const struct MDPFootballLiveMatchTeamStatisticsModelRelationships {
	__unsafe_unretained NSString *stats;
	__unsafe_unretained NSString *team;
} MDPFootballLiveMatchTeamStatisticsModelRelationships;

@class MDPLiveMatchTeamStatModel;
@class MDPLiveMatchTeamModel;

@interface _MDPFootballLiveMatchTeamStatisticsModel : NSManagedObject

@property (nonatomic, strong) NSString* idCompetition;

//- (BOOL)validateIdCompetition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idMatch;

//- (BOOL)validateIdMatch:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSeason;

//- (BOOL)validateIdSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idTeam;

//- (BOOL)validateIdTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *stats;

- (NSMutableSet*)statsSet;

@property (nonatomic, strong) MDPLiveMatchTeamModel *team;

//- (BOOL)validateTeam:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPFootballLiveMatchTeamStatisticsModel (StatsCoreDataGeneratedAccessors)
- (void)addStats:(NSSet*)value_;
- (void)removeStats:(NSSet*)value_;
- (void)addStatsObject:(MDPLiveMatchTeamStatModel*)value_;
- (void)removeStatsObject:(MDPLiveMatchTeamStatModel*)value_;
@end

@interface _MDPFootballLiveMatchTeamStatisticsModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdCompetition;
- (void)setPrimitiveIdCompetition:(NSString*)value;

- (NSString*)primitiveIdMatch;
- (void)setPrimitiveIdMatch:(NSString*)value;

- (NSString*)primitiveIdSeason;
- (void)setPrimitiveIdSeason:(NSString*)value;

- (NSString*)primitiveIdTeam;
- (void)setPrimitiveIdTeam:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSMutableSet*)primitiveStats;
- (void)setPrimitiveStats:(NSMutableSet*)value;

- (MDPLiveMatchTeamModel*)primitiveTeam;
- (void)setPrimitiveTeam:(MDPLiveMatchTeamModel*)value;

@end
