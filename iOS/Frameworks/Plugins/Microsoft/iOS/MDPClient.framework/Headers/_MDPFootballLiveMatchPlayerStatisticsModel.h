//
//  _MDPFootballLiveMatchPlayerStatisticsModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPFootballLiveMatchPlayerStatisticsModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPFootballLiveMatchPlayerStatisticsModelAttributes {
	__unsafe_unretained NSString *idCompetition;
	__unsafe_unretained NSString *idMatch;
	__unsafe_unretained NSString *idPlayer;
	__unsafe_unretained NSString *idSeason;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *playerName;
} MDPFootballLiveMatchPlayerStatisticsModelAttributes;

extern const struct MDPFootballLiveMatchPlayerStatisticsModelRelationships {
	__unsafe_unretained NSString *stats;
} MDPFootballLiveMatchPlayerStatisticsModelRelationships;

@class MDPStatisticTypeModel;

@interface _MDPFootballLiveMatchPlayerStatisticsModel : NSManagedObject

@property (nonatomic, strong) NSString* idCompetition;

//- (BOOL)validateIdCompetition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idMatch;

//- (BOOL)validateIdMatch:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idPlayer;

//- (BOOL)validateIdPlayer:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSeason;

//- (BOOL)validateIdSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* playerName;

//- (BOOL)validatePlayerName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *stats;

- (NSMutableSet*)statsSet;

@end

@interface _MDPFootballLiveMatchPlayerStatisticsModel (StatsCoreDataGeneratedAccessors)
- (void)addStats:(NSSet*)value_;
- (void)removeStats:(NSSet*)value_;
- (void)addStatsObject:(MDPStatisticTypeModel*)value_;
- (void)removeStatsObject:(MDPStatisticTypeModel*)value_;
@end

@interface _MDPFootballLiveMatchPlayerStatisticsModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveIdCompetition;
- (void)setPrimitiveIdCompetition:(NSString*)value;

- (NSString*)primitiveIdMatch;
- (void)setPrimitiveIdMatch:(NSString*)value;

- (NSString*)primitiveIdPlayer;
- (void)setPrimitiveIdPlayer:(NSString*)value;

- (NSString*)primitiveIdSeason;
- (void)setPrimitiveIdSeason:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitivePlayerName;
- (void)setPrimitivePlayerName:(NSString*)value;

- (NSMutableSet*)primitiveStats;
- (void)setPrimitiveStats:(NSMutableSet*)value;

@end
