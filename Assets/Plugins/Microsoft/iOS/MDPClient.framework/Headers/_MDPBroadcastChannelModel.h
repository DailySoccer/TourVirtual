//
//  _MDPBroadcastChannelModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPBroadcastChannelModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPBroadcastChannelModelAttributes {
	__unsafe_unretained NSString *channel;
	__unsafe_unretained NSString *country;
	__unsafe_unretained NSString *languageCode;
	__unsafe_unretained NSString *lastUpdateAt;
} MDPBroadcastChannelModelAttributes;

extern const struct MDPBroadcastChannelModelRelationships {
	__unsafe_unretained NSString *competitionMatchChannels;
	__unsafe_unretained NSString *matchChannels;
} MDPBroadcastChannelModelRelationships;

@class MDPCompetitionMatchModel;
@class MDPMatchModel;

@interface _MDPBroadcastChannelModel : NSManagedObject

@property (nonatomic, strong) NSString* channel;

//- (BOOL)validateChannel:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* country;

//- (BOOL)validateCountry:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* languageCode;

//- (BOOL)validateLanguageCode:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPCompetitionMatchModel *competitionMatchChannels;

//- (BOOL)validateCompetitionMatchChannels:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPMatchModel *matchChannels;

//- (BOOL)validateMatchChannels:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPBroadcastChannelModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveChannel;
- (void)setPrimitiveChannel:(NSString*)value;

- (NSString*)primitiveCountry;
- (void)setPrimitiveCountry:(NSString*)value;

- (NSString*)primitiveLanguageCode;
- (void)setPrimitiveLanguageCode:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (MDPCompetitionMatchModel*)primitiveCompetitionMatchChannels;
- (void)setPrimitiveCompetitionMatchChannels:(MDPCompetitionMatchModel*)value;

- (MDPMatchModel*)primitiveMatchChannels;
- (void)setPrimitiveMatchChannels:(MDPMatchModel*)value;

@end
