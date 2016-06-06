//
//  _MDPMatchSubscriptionInformationModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPMatchSubscriptionInformationModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPMatchSubscriptionInformationModelAttributes {
	__unsafe_unretained NSString *competitionId;
	__unsafe_unretained NSString *competitionType;
	__unsafe_unretained NSString *details;
	__unsafe_unretained NSString *idMatchSubsciptionInformation;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *mainActors;
	__unsafe_unretained NSString *matchEventTypes;
	__unsafe_unretained NSString *matchId;
	__unsafe_unretained NSString *published;
	__unsafe_unretained NSString *recordingDate;
	__unsafe_unretained NSString *season;
	__unsafe_unretained NSString *seasonId;
	__unsafe_unretained NSString *section;
	__unsafe_unretained NSString *title;
	__unsafe_unretained NSString *videoType;
} MDPMatchSubscriptionInformationModelAttributes;

extern const struct MDPMatchSubscriptionInformationModelRelationships {
	__unsafe_unretained NSString *pagedMatchSubscriptionInformationResults;
} MDPMatchSubscriptionInformationModelRelationships;

@class MDPPagedMatchSubscriptionInformationModel;

@interface _MDPMatchSubscriptionInformationModel : NSManagedObject

@property (nonatomic, strong) NSString* competitionId;

//- (BOOL)validateCompetitionId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* competitionType;

//- (BOOL)validateCompetitionType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* details;

//- (BOOL)validateDetails:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idMatchSubsciptionInformation;

//- (BOOL)validateIdMatchSubsciptionInformation:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* mainActors;

//- (BOOL)validateMainActors:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* matchEventTypes;

//- (BOOL)validateMatchEventTypes:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* matchId;

//- (BOOL)validateMatchId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* published;

@property (atomic) BOOL publishedValue;
- (BOOL)publishedValue;
- (void)setPublishedValue:(BOOL)value_;

//- (BOOL)validatePublished:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* recordingDate;

//- (BOOL)validateRecordingDate:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* season;

//- (BOOL)validateSeason:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* seasonId;

//- (BOOL)validateSeasonId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* section;

//- (BOOL)validateSection:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* title;

//- (BOOL)validateTitle:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSData* videoType;

//- (BOOL)validateVideoType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPPagedMatchSubscriptionInformationModel *pagedMatchSubscriptionInformationResults;

//- (BOOL)validatePagedMatchSubscriptionInformationResults:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPMatchSubscriptionInformationModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveCompetitionId;
- (void)setPrimitiveCompetitionId:(NSString*)value;

- (NSString*)primitiveCompetitionType;
- (void)setPrimitiveCompetitionType:(NSString*)value;

- (NSString*)primitiveDetails;
- (void)setPrimitiveDetails:(NSString*)value;

- (NSString*)primitiveIdMatchSubsciptionInformation;
- (void)setPrimitiveIdMatchSubsciptionInformation:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSData*)primitiveMainActors;
- (void)setPrimitiveMainActors:(NSData*)value;

- (NSData*)primitiveMatchEventTypes;
- (void)setPrimitiveMatchEventTypes:(NSData*)value;

- (NSString*)primitiveMatchId;
- (void)setPrimitiveMatchId:(NSString*)value;

- (NSNumber*)primitivePublished;
- (void)setPrimitivePublished:(NSNumber*)value;

- (BOOL)primitivePublishedValue;
- (void)setPrimitivePublishedValue:(BOOL)value_;

- (NSDate*)primitiveRecordingDate;
- (void)setPrimitiveRecordingDate:(NSDate*)value;

- (NSString*)primitiveSeason;
- (void)setPrimitiveSeason:(NSString*)value;

- (NSString*)primitiveSeasonId;
- (void)setPrimitiveSeasonId:(NSString*)value;

- (NSString*)primitiveSection;
- (void)setPrimitiveSection:(NSString*)value;

- (NSString*)primitiveTitle;
- (void)setPrimitiveTitle:(NSString*)value;

- (NSData*)primitiveVideoType;
- (void)setPrimitiveVideoType:(NSData*)value;

- (MDPPagedMatchSubscriptionInformationModel*)primitivePagedMatchSubscriptionInformationResults;
- (void)setPrimitivePagedMatchSubscriptionInformationResults:(MDPPagedMatchSubscriptionInformationModel*)value;

@end
