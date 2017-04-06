//
//  _MDPCareerDetailModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPCareerDetailModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPCareerDetailModelAttributes {
	__unsafe_unretained NSString *competitionName;
	__unsafe_unretained NSString *gamesPlayed;
	__unsafe_unretained NSString *goals;
	__unsafe_unretained NSString *idCompetition;
	__unsafe_unretained NSString *idSeason;
	__unsafe_unretained NSString *idTeam;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *redCards;
	__unsafe_unretained NSString *season;
	__unsafe_unretained NSString *teamName;
	__unsafe_unretained NSString *yellowCards;
} MDPCareerDetailModelAttributes;

extern const struct MDPCareerDetailModelRelationships {
	__unsafe_unretained NSString *playerDomesticLeague;
	__unsafe_unretained NSString *playerInternational;
} MDPCareerDetailModelRelationships;

@class MDPPlayerModel;
@class MDPPlayerModel;

@interface _MDPCareerDetailModel : NSManagedObject

@property (nonatomic, strong) NSString* competitionName;

//- (BOOL)validateCompetitionName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* gamesPlayed;

@property (atomic) uint64_t gamesPlayedValue;
- (uint64_t)gamesPlayedValue;
- (void)setGamesPlayedValue:(uint64_t)value_;

//- (BOOL)validateGamesPlayed:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* goals;

@property (atomic) uint64_t goalsValue;
- (uint64_t)goalsValue;
- (void)setGoalsValue:(uint64_t)value_;

//- (BOOL)validateGoals:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idCompetition;

//- (BOOL)validateIdCompetition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSeason;

//- (BOOL)validateIdSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idTeam;

//- (BOOL)validateIdTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* redCards;

@property (atomic) uint64_t redCardsValue;
- (uint64_t)redCardsValue;
- (void)setRedCardsValue:(uint64_t)value_;

//- (BOOL)validateRedCards:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* season;

//- (BOOL)validateSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* teamName;

//- (BOOL)validateTeamName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* yellowCards;

@property (atomic) uint64_t yellowCardsValue;
- (uint64_t)yellowCardsValue;
- (void)setYellowCardsValue:(uint64_t)value_;

//- (BOOL)validateYellowCards:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPlayerModel *playerDomesticLeague;

//- (BOOL)validatePlayerDomesticLeague:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPlayerModel *playerInternational;

//- (BOOL)validatePlayerInternational:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPCareerDetailModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveCompetitionName;
- (void)setPrimitiveCompetitionName:(NSString*)value;

- (NSNumber*)primitiveGamesPlayed;
- (void)setPrimitiveGamesPlayed:(NSNumber*)value;

- (uint64_t)primitiveGamesPlayedValue;
- (void)setPrimitiveGamesPlayedValue:(uint64_t)value_;

- (NSNumber*)primitiveGoals;
- (void)setPrimitiveGoals:(NSNumber*)value;

- (uint64_t)primitiveGoalsValue;
- (void)setPrimitiveGoalsValue:(uint64_t)value_;

- (NSString*)primitiveIdCompetition;
- (void)setPrimitiveIdCompetition:(NSString*)value;

- (NSString*)primitiveIdSeason;
- (void)setPrimitiveIdSeason:(NSString*)value;

- (NSString*)primitiveIdTeam;
- (void)setPrimitiveIdTeam:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSNumber*)primitiveRedCards;
- (void)setPrimitiveRedCards:(NSNumber*)value;

- (uint64_t)primitiveRedCardsValue;
- (void)setPrimitiveRedCardsValue:(uint64_t)value_;

- (NSString*)primitiveSeason;
- (void)setPrimitiveSeason:(NSString*)value;

- (NSString*)primitiveTeamName;
- (void)setPrimitiveTeamName:(NSString*)value;

- (NSNumber*)primitiveYellowCards;
- (void)setPrimitiveYellowCards:(NSNumber*)value;

- (uint64_t)primitiveYellowCardsValue;
- (void)setPrimitiveYellowCardsValue:(uint64_t)value_;

- (MDPPlayerModel*)primitivePlayerDomesticLeague;
- (void)setPrimitivePlayerDomesticLeague:(MDPPlayerModel*)value;

- (MDPPlayerModel*)primitivePlayerInternational;
- (void)setPrimitivePlayerInternational:(MDPPlayerModel*)value;

@end
