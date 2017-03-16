//
//  _MDPLiveEventModel.m
//  MDPClient
//
//  Created automatically with Mogenerator Templates.
//  Copyright (c) 2014 Microsoft. All rights reserved.
//

// DO NOT EDIT. This file is machine-generated and constantly overwritten.
// Make changes to MDPLiveEventModel.h instead.

@import CoreData;
#import "NSManagedObject+MDPManagedObject.h"

extern const struct MDPLiveEventModelAttributes {
	__unsafe_unretained NSString *competitionType;
	__unsafe_unretained NSString *contentKeyId;
	__unsafe_unretained NSString *encrypted;
	__unsafe_unretained NSString *eventDateTime;
	__unsafe_unretained NSString *idLiveEvent;
	__unsafe_unretained NSString *lastUpdateAt;
	__unsafe_unretained NSString *title;
	__unsafe_unretained NSString *urlDash;
	__unsafe_unretained NSString *urlHLS;
	__unsafe_unretained NSString *urlSmoothStreaming;
} MDPLiveEventModelAttributes;

extern const struct MDPLiveEventModelRelationships {
	__unsafe_unretained NSString *requestLiveEvent;
} MDPLiveEventModelRelationships;

@class MDPRequestLiveEventModel;

@interface _MDPLiveEventModel : NSManagedObject

@property (nonatomic, strong) NSString* competitionType;

//- (BOOL)validateCompetitionType:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* contentKeyId;

//- (BOOL)validateContentKeyId:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSNumber* encrypted;

@property (atomic) BOOL encryptedValue;
- (BOOL)encryptedValue;
- (void)setEncryptedValue:(BOOL)value_;

//- (BOOL)validateEncrypted:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* eventDateTime;

//- (BOOL)validateEventDateTime:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* idLiveEvent;

//- (BOOL)validateIdLiveEvent:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSDate* lastUpdateAt;

//- (BOOL)validateLastUpdateAt:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* title;

//- (BOOL)validateTitle:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* urlDash;

//- (BOOL)validateUrlDash:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* urlHLS;

//- (BOOL)validateUrlHLS:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) NSString* urlSmoothStreaming;

//- (BOOL)validateUrlSmoothStreaming:(id*)value_ error:(NSError**)error_;

@property (nonatomic, strong) MDPRequestLiveEventModel *requestLiveEvent;

//- (BOOL)validateRequestLiveEvent:(id*)value_ error:(NSError**)error_;

@end

@interface _MDPLiveEventModel (CoreDataGeneratedPrimitiveAccessors)

- (NSString*)primitiveCompetitionType;
- (void)setPrimitiveCompetitionType:(NSString*)value;

- (NSString*)primitiveContentKeyId;
- (void)setPrimitiveContentKeyId:(NSString*)value;

- (NSNumber*)primitiveEncrypted;
- (void)setPrimitiveEncrypted:(NSNumber*)value;

- (BOOL)primitiveEncryptedValue;
- (void)setPrimitiveEncryptedValue:(BOOL)value_;

- (NSDate*)primitiveEventDateTime;
- (void)setPrimitiveEventDateTime:(NSDate*)value;

- (NSString*)primitiveIdLiveEvent;
- (void)setPrimitiveIdLiveEvent:(NSString*)value;

- (NSDate*)primitiveLastUpdateAt;
- (void)setPrimitiveLastUpdateAt:(NSDate*)value;

- (NSString*)primitiveTitle;
- (void)setPrimitiveTitle:(NSString*)value;

- (NSString*)primitiveUrlDash;
- (void)setPrimitiveUrlDash:(NSString*)value;

- (NSString*)primitiveUrlHLS;
- (void)setPrimitiveUrlHLS:(NSString*)value;

- (NSString*)primitiveUrlSmoothStreaming;
- (void)setPrimitiveUrlSmoothStreaming:(NSString*)value;

- (MDPRequestLiveEventModel*)primitiveRequestLiveEvent;
- (void)setPrimitiveRequestLiveEvent:(MDPRequestLiveEventModel*)value;

@end
