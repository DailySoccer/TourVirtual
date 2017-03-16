//
//  _MDPCompactCompetitionMatchModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPCompactCompetitionMatchModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPCompactCompetitionMatchModelAttributes {
	__unsafe_unretained NSString *awayTeamBadgeThumbnailUrl;
	__unsafe_unretained NSString *awayTeamBadgeUrl;
	__unsafe_unretained NSString *awayTeamGoals;
	__unsafe_unretained NSString *awayTeamName;
	__unsafe_unretained NSString *awayTeamPenaltyGoals;
	__unsafe_unretained NSString *competitionName;
	__unsafe_unretained NSString *date;
	__unsafe_unretained NSString *homeTeamBadgeThumbnailUrl;
	__unsafe_unretained NSString *homeTeamBadgeUrl;
	__unsafe_unretained NSString *homeTeamGoals;
	__unsafe_unretained NSString *homeTeamName;
	__unsafe_unretained NSString *homeTeamPenaltyGoals;
	__unsafe_unretained NSString *idAwayTeam;
	__unsafe_unretained NSString *idCompetition;
	__unsafe_unretained NSString *idHomeTeam;
	__unsafe_unretained NSString *idMatch;
	__unsafe_unretained NSString *idSeason;
	__unsafe_unretained NSString *isHomeMatch;
	__unsafe_unretained NSString *language;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *matchDay;
	__unsafe_unretained NSString *seasonName;
	__unsafe_unretained NSString *showBuyTickets;
	__unsafe_unretained NSString *sport;
} MDPCompactCompetitionMatchModelAttributes;

extern const struct MDPCompactCompetitionMatchModelRelationships {
	__unsafe_unretained NSString *leg;
	__unsafe_unretained NSString *pagedCompactCompetitionMatchesItems;
	__unsafe_unretained NSString *period;
	__unsafe_unretained NSString *stage;
} MDPCompactCompetitionMatchModelRelationships;

@class MDPKeyValueObjectModel;
@class MDPPagedCompactCompetitionMatchesModel;
@class MDPKeyValueObjectModel;
@class MDPKeyValueObjectModel;

@interface _MDPCompactCompetitionMatchModel : NSManagedObject

@property (nonatomic, strong) NSString* awayTeamBadgeThumbnailUrl;

//- (BOOL)validateAwayTeamBadgeThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* awayTeamBadgeUrl;

//- (BOOL)validateAwayTeamBadgeUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* awayTeamGoals;

@property (atomic) int64_t awayTeamGoalsValue;
- (int64_t)awayTeamGoalsValue;
- (void)setAwayTeamGoalsValue:(int64_t)value_;

//- (BOOL)validateAwayTeamGoals:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* awayTeamName;

//- (BOOL)validateAwayTeamName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* awayTeamPenaltyGoals;

@property (atomic) int64_t awayTeamPenaltyGoalsValue;
- (int64_t)awayTeamPenaltyGoalsValue;
- (void)setAwayTeamPenaltyGoalsValue:(int64_t)value_;

//- (BOOL)validateAwayTeamPenaltyGoals:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* competitionName;

//- (BOOL)validateCompetitionName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* date;

//- (BOOL)validateDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* homeTeamBadgeThumbnailUrl;

//- (BOOL)validateHomeTeamBadgeThumbnailUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* homeTeamBadgeUrl;

//- (BOOL)validateHomeTeamBadgeUrl:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* homeTeamGoals;

@property (atomic) int64_t homeTeamGoalsValue;
- (int64_t)homeTeamGoalsValue;
- (void)setHomeTeamGoalsValue:(int64_t)value_;

//- (BOOL)validateHomeTeamGoals:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* homeTeamName;

//- (BOOL)validateHomeTeamName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* homeTeamPenaltyGoals;

@property (atomic) int64_t homeTeamPenaltyGoalsValue;
- (int64_t)homeTeamPenaltyGoalsValue;
- (void)setHomeTeamPenaltyGoalsValue:(int64_t)value_;

//- (BOOL)validateHomeTeamPenaltyGoals:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idAwayTeam;

//- (BOOL)validateIdAwayTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idCompetition;

//- (BOOL)validateIdCompetition:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idHomeTeam;

//- (BOOL)validateIdHomeTeam:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idMatch;

//- (BOOL)validateIdMatch:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idSeason;

//- (BOOL)validateIdSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* isHomeMatch;

@property (atomic) BOOL isHomeMatchValue;
- (BOOL)isHomeMatchValue;
- (void)setIsHomeMatchValue:(BOOL)value_;

//- (BOOL)validateIsHomeMatch:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* language;

//- (BOOL)validateLanguage:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* matchDay;

//- (BOOL)validateMatchDay:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* seasonName;

//- (BOOL)validateSeasonName:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* showBuyTickets;

@property (atomic) BOOL showBuyTicketsValue;
- (BOOL)showBuyTicketsValue;
- (void)setShowBuyTicketsValue:(BOOL)value_;

//- (BOOL)validateShowBuyTickets:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* sport;

@property (atomic) int16_t sportValue;
- (int16_t)sportValue;
- (void)setSportValue:(int16_t)value_;

//- (BOOL)validateSport:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPKeyValueObjectModel *leg;

//- (BOOL)validateLeg:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSSet *pagedCompactCompetitionMatchesItems;

- (NSMutableSet*)pagedCompactCompetitionMatchesItemsSet;

@property (nonatomic, strong) MDPKeyValueObjectModel *period;

//- (BOOL)validatePeriod:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPKeyValueObjectModel *stage;

//- (BOOL)validateStage:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPCompactCompetitionMatchModel (PagedCompactCompetitionMatchesItemsCoreDataGeneratedAccessors)
- (void)addPagedCompactCompetitionMatchesItems:(NSSet*)value_;
- (void)removePagedCompactCompetitionMatchesItems:(NSSet*)value_;
- (void)addPagedCompactCompetitionMatchesItemsObject:(MDPPagedCompactCompetitionMatchesModel*)value_;
- (void)removePagedCompactCompetitionMatchesItemsObject:(MDPPagedCompactCompetitionMatchesModel*)value_;
@end

@interface _MDPCompactCompetitionMatchModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveAwayTeamBadgeThumbnailUrl;
- (void)setPrimitiveAwayTeamBadgeThumbnailUrl:(NSString*)value;

- (NSString*)primitiveAwayTeamBadgeUrl;
- (void)setPrimitiveAwayTeamBadgeUrl:(NSString*)value;

- (NSNumber*)primitiveAwayTeamGoals;
- (void)setPrimitiveAwayTeamGoals:(NSNumber*)value;

- (int64_t)primitiveAwayTeamGoalsValue;
- (void)setPrimitiveAwayTeamGoalsValue:(int64_t)value_;

- (NSString*)primitiveAwayTeamName;
- (void)setPrimitiveAwayTeamName:(NSString*)value;

- (NSNumber*)primitiveAwayTeamPenaltyGoals;
- (void)setPrimitiveAwayTeamPenaltyGoals:(NSNumber*)value;

- (int64_t)primitiveAwayTeamPenaltyGoalsValue;
- (void)setPrimitiveAwayTeamPenaltyGoalsValue:(int64_t)value_;

- (NSString*)primitiveCompetitionName;
- (void)setPrimitiveCompetitionName:(NSString*)value;

- (NSDate*)primitiveDate;
- (void)setPrimitiveDate:(NSDate*)value;

- (NSString*)primitiveHomeTeamBadgeThumbnailUrl;
- (void)setPrimitiveHomeTeamBadgeThumbnailUrl:(NSString*)value;

- (NSString*)primitiveHomeTeamBadgeUrl;
- (void)setPrimitiveHomeTeamBadgeUrl:(NSString*)value;

- (NSNumber*)primitiveHomeTeamGoals;
- (void)setPrimitiveHomeTeamGoals:(NSNumber*)value;

- (int64_t)primitiveHomeTeamGoalsValue;
- (void)setPrimitiveHomeTeamGoalsValue:(int64_t)value_;

- (NSString*)primitiveHomeTeamName;
- (void)setPrimitiveHomeTeamName:(NSString*)value;

- (NSNumber*)primitiveHomeTeamPenaltyGoals;
- (void)setPrimitiveHomeTeamPenaltyGoals:(NSNumber*)value;

- (int64_t)primitiveHomeTeamPenaltyGoalsValue;
- (void)setPrimitiveHomeTeamPenaltyGoalsValue:(int64_t)value_;

- (NSString*)primitiveIdAwayTeam;
- (void)setPrimitiveIdAwayTeam:(NSString*)value;

- (NSString*)primitiveIdCompetition;
- (void)setPrimitiveIdCompetition:(NSString*)value;

- (NSString*)primitiveIdHomeTeam;
- (void)setPrimitiveIdHomeTeam:(NSString*)value;

- (NSString*)primitiveIdMatch;
- (void)setPrimitiveIdMatch:(NSString*)value;

- (NSString*)primitiveIdSeason;
- (void)setPrimitiveIdSeason:(NSString*)value;

- (NSNumber*)primitiveIsHomeMatch;
- (void)setPrimitiveIsHomeMatch:(NSNumber*)value;

- (BOOL)primitiveIsHomeMatchValue;
- (void)setPrimitiveIsHomeMatchValue:(BOOL)value_;

- (NSString*)primitiveLanguage;
- (void)setPrimitiveLanguage:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveMatchDay;
- (void)setPrimitiveMatchDay:(NSString*)value;

- (NSString*)primitiveSeasonName;
- (void)setPrimitiveSeasonName:(NSString*)value;

- (NSNumber*)primitiveShowBuyTickets;
- (void)setPrimitiveShowBuyTickets:(NSNumber*)value;

- (BOOL)primitiveShowBuyTicketsValue;
- (void)setPrimitiveShowBuyTicketsValue:(BOOL)value_;

- (NSNumber*)primitiveSport;
- (void)setPrimitiveSport:(NSNumber*)value;

- (int16_t)primitiveSportValue;
- (void)setPrimitiveSportValue:(int16_t)value_;

- (MDPKeyValueObjectModel*)primitiveLeg;
- (void)setPrimitiveLeg:(MDPKeyValueObjectModel*)value;

- (NSMutableSet*)primitivePagedCompactCompetitionMatchesItems;
- (void)setPrimitivePagedCompactCompetitionMatchesItems:(NSMutableSet*)value;

- (MDPKeyValueObjectModel*)primitivePeriod;
- (void)setPrimitivePeriod:(MDPKeyValueObjectModel*)value;

- (MDPKeyValueObjectModel*)primitiveStage;
- (void)setPrimitiveStage:(MDPKeyValueObjectModel*)value;

@end
